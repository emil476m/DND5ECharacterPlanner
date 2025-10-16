using Dapper;
using Core.Enums;
using Core.Interfaces;
using Core.Models;
using Core.Models.Feats;
using Core.Models.Miscellaneous;
using infrastructure.DatabaseModels.Feats;
using infrastructure.Mappers;
using Npgsql;

namespace infrastructure.Implementations;

public class FeatRepository : IRepository<FeatModel>
{
    
    private readonly NpgsqlDataSource _dataSource;
    
    
    public FeatRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    /// <summary>
    /// Method that creates a new feat and inserts it into the database
    /// </summary>
    /// <param name="item">an object containing the data for the new feat</param>
    /// <returns>returns the object if the transaction is complete</returns>
    /// <exception cref="Exception"></exception>
    
    public async Task<FeatModel> Create(FeatModel item)
    {
        var dbFeat = item.ToDbModel();
        
        using var conn = _dataSource.OpenConnection();
        using var transaction = conn.BeginTransaction();

        try
        {
            await InsertEntity(conn, dbFeat, transaction);
            await InsertFeat(conn, dbFeat, transaction);
            await InsertFixedAbilityScoreIncreases(conn, dbFeat, transaction);
            await InsertChoices(conn, dbFeat, transaction);

            await transaction.CommitAsync();
            return item;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Could not create feat", ex);
        }
    }
    
    private async Task InsertEntity(NpgsqlConnection conn, FeatDbModel item, NpgsqlTransaction transaction)
    {
        var sql = @"
        INSERT INTO dnd_entity (id, name, is_public, is_official, created_by_user_id, created_at, used_ruleset, entity_type)
        VALUES(@Id, @Name, @IsPublic, @IsOfficial, @CreatedByUserId, @CreatedAt, @UsedRuleset, @Type);";

        await conn.ExecuteAsync(sql, item, transaction);
    }
    
    private async Task InsertFeat(NpgsqlConnection conn, FeatDbModel item, NpgsqlTransaction transaction)
    {
        var sql = "INSERT INTO feat (id, effect) VALUES (@Id, @Effect);";
        await conn.ExecuteAsync(sql, item, transaction);
    }
    
    private async Task InsertFixedAbilityScoreIncreases(NpgsqlConnection conn, FeatDbModel item, NpgsqlTransaction transaction)
    {
        if (item.AbilityScoreIncreases == null || !item.AbilityScoreIncreases.Any()) return;
        
        Console.WriteLine("Found AbilityScoreIncreases trying to save to database");

        var sql = "INSERT INTO ability_score_increase (entity_id, ability, amount) VALUES (@EntityId, @Ability, @Amount);";

        foreach (var asi in item.AbilityScoreIncreases)
        {
            await conn.ExecuteAsync(sql, new { EntityId = item.Id, asi.Ability, asi.Amount }, transaction);
        }
    }
    
    private async Task InsertChoices(NpgsqlConnection conn, FeatDbModel item, NpgsqlTransaction transaction)
    {
        // Effect choices
        if (item.EffectChoices != null)
        {
            foreach (var choice in item.EffectChoices)
            {
                var choiceId = await InsertChoice(conn, item.Id, choice.Description, choice.NumberToChoose, "Effect", transaction);
                foreach (var option in choice.Options)
                {
                    await InsertChoiceOption(conn, choiceId, option, transaction);
                }
            }
        }

        // Ability score increase choices
        if (item.AbilityScoreIncreaseChoices != null)
        {
            foreach (var choice in item.AbilityScoreIncreaseChoices)
            {
                var choiceId = await InsertChoice(conn, item.Id, choice.Description, choice.NumberToChoose, "AbilityScoreIncrease", transaction);
                foreach (var option in choice.Options)
                {
                    var optionValue = $"{option.Ability}+{option.Amount}";
                    await InsertChoiceOption(conn, choiceId, optionValue, transaction);
                }
            }
        }
    }

    private async Task<int> InsertChoice(NpgsqlConnection conn, Guid entityId, string description, int numberToChoose, string type, NpgsqlTransaction transaction)
    {
        var sql = @"
        INSERT INTO choice (entity_id, description, number_to_choose, type)
        VALUES (@EntityId, @Description, @NumberToChoose, @Type)
        RETURNING id;";
        return await conn.ExecuteScalarAsync<int>(sql, new { EntityId = entityId, Description = description, NumberToChoose = numberToChoose, Type = type }, transaction);
    }

    private async Task InsertChoiceOption(NpgsqlConnection conn, int choiceId, string value, NpgsqlTransaction transaction)
    {
        var sql = "INSERT INTO choice_option (choice_id, value) VALUES (@ChoiceId, @Value);";
        await conn.ExecuteAsync(sql, new { ChoiceId = choiceId, Value = value }, transaction);
    }
    

    
    

    /// <summary>
    /// Method that deletes a feat
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> Delete(Guid id)
    {
        using var conn = _dataSource.OpenConnection();
        var sql = "DELETE FROM dnd_entity WHERE id = @Id;";
        return await conn.ExecuteAsync(sql, new { Id = id }) > 0;
    }
    
    /// <summary>
    /// Method to update a feat
    /// </summary>
    /// <param name="id"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<FeatModel> Update(Guid id, FeatModel item)
    {
        using var conn = _dataSource.OpenConnection();
        using var transaction = conn.BeginTransaction();

        try
        {
            var dbFeat = item.ToDbModel();

            // Update dndEntity
            var updateEntitySql = @"UPDATE dnd_entity
                SET name = @Name, is_public = @IsPublic, is_official = @IsOfficial,
                used_ruleset = @UsedRuleset, entity_type = @Type WHERE id = @Id;";
            await conn.ExecuteAsync(updateEntitySql, dbFeat, transaction);

            // Update feat
            var updateFeatSql = "UPDATE feat SET effect = @Effect WHERE id = @Id;";
            await conn.ExecuteAsync(updateFeatSql, dbFeat, transaction);

            // clear and reinsert subtable data
            await conn.ExecuteAsync("DELETE FROM ability_score_increase WHERE entity_id = @Id;", new { Id = id }, transaction);
            await conn.ExecuteAsync("DELETE FROM choice_option WHERE choice_id IN (SELECT id FROM choice WHERE entity_id = @Id);", new { Id = id }, transaction);
            await conn.ExecuteAsync("DELETE FROM choice WHERE entity_id = @Id;", new { Id = id }, transaction);

            await InsertFixedAbilityScoreIncreases(conn, dbFeat, transaction);
            await InsertChoices(conn, dbFeat, transaction);

            await transaction.CommitAsync();
            return item;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Could not update feat", ex);
        }
    }
    
    /// <summary>
    /// Reads and returns a feat
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<FeatModel> GetResult(Guid id)
    {
        using var conn = _dataSource.OpenConnection();

        var sql = $@"
            SELECT 
                e.id AS {nameof(FeatDbModel.Id)},
                e.name AS {nameof(FeatDbModel.Name)},
                e.is_public AS {nameof(FeatDbModel.IsPublic)},
                e.is_official AS {nameof(FeatDbModel.IsOfficial)},
                e.created_by_user_id AS {nameof(FeatDbModel.CreatedByUserId)},
                e.created_at AS {nameof(FeatDbModel.CreatedAt)},
                e.used_ruleset AS {nameof(FeatDbModel.UsedRuleset)},
                e.entity_type AS {nameof(FeatDbModel.Type)},
                f.effect AS {nameof(FeatDbModel.Effect)}
            FROM dnd_entity e
            JOIN feat f ON e.id = f.id
            WHERE e.id = @Id;";

        var entity = await conn.QuerySingleOrDefaultAsync<FeatDbModel>(sql, new { Id = id });
        if (entity == null) return null;

        var sqlScore = @"SELECT ability, amount FROM ability_score_increase WHERE entity_id = @Id";
        
        // Load Ability Score Increases
        entity.AbilityScoreIncreases = (await conn.QueryAsync<AbilityScoreIncreaseModel>(sqlScore, new { Id = id })).ToList();

        // Load Choices
        var choices = await conn.QueryAsync<dynamic>("SELECT * FROM choice WHERE entity_id = @Id", new { Id = id });

        foreach (var choice in choices)
        {
            var options = await conn.QueryAsync<string>("SELECT value FROM choice_option WHERE choice_id = @ChoiceId", new { ChoiceId = choice.id });

            if (choice.type == "Effect")
            {
                entity.EffectChoices.Add(new ChoiceModel<string>
                {
                    Description = choice.description,
                    NumberToChoose = choice.number_to_choose,
                    Options = options.ToList()
                });
            }
            else if (choice.type == "AbilityScoreIncrease")
            {
                var asiOptions = options
                    .Select(o =>
                    {
                        var parts = o.Split('+');
                        return new AbilityScoreIncreaseModel { Ability = parts[0], Amount = int.Parse(parts[1]) };
                    })
                    .ToList();

                entity.AbilityScoreIncreaseChoices.Add(new ChoiceModel<AbilityScoreIncreaseModel>
                {
                    Description = choice.description,
                    NumberToChoose = choice.number_to_choose,
                    Options = asiOptions
                });
            }
        }

        return entity.ToFeatModel();
    }

    /// <summary>
    /// gets a simple list of all the feats, simple meaning with minimal data
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<DndEntitySimpleModel>> GetSimpleList()
    {
        try
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            var sql = @$"SELECT 
                            id AS {nameof(DndEntitySimpleModel.Id)}, 
                            name AS {nameof(DndEntitySimpleModel.Name)}, 
                            is_public AS {nameof(DndEntitySimpleModel.IsPublic)}, 
                            used_ruleset AS {nameof(DndEntitySimpleModel.UsedRuleset)}
                         FROM dnd_entity WHERE entity_type = @EntityType;";

            return await conn.QueryAsync<DndEntitySimpleModel>(sql, new { EntityType = EntityType.Feat });
        }
        catch (Exception ex)
        {
            throw new Exception("Could not get simple feat list", ex);
        }
    }
    
    /// <summary>
    /// Gets all feats with all their data
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<FeatModel>> GetDetailedList()
    {
        using var conn = await _dataSource.OpenConnectionAsync();

        // Load feats
        var feats = await LoadBaseFeats(conn);
        if (!feats.Any()) return Enumerable.Empty<FeatModel>();

        // Load ability score increases
        await LoadAbilityScoreIncreases(conn, feats);

        // Load choices + options
        await LoadChoices(conn, feats);
    
        return feats.Values.Select(f => f.ToFeatModel());
    }

    private async Task<Dictionary<Guid, FeatDbModel>> LoadBaseFeats(NpgsqlConnection conn)
    {
        var sql = $@"
        SELECT
            e.id AS {nameof(FeatDbModel.Id)},
            e.name AS {nameof(FeatDbModel.Name)},
            e.is_public AS {nameof(FeatDbModel.IsPublic)},
            e.is_official AS {nameof(FeatDbModel.IsOfficial)},
            e.created_by_user_id AS {nameof(FeatDbModel.CreatedByUserId)},
            e.created_at AS {nameof(FeatDbModel.CreatedAt)},
            e.used_ruleset AS {nameof(FeatDbModel.UsedRuleset)},
            e.entity_type AS {nameof(FeatDbModel.Type)},
            f.effect AS {nameof(FeatDbModel.Effect)}
        FROM dnd_entity e
        JOIN feat f ON e.id = f.id
        WHERE e.entity_type = @EntityType;";

        var feats = await conn.QueryAsync<FeatDbModel>(sql, new { EntityType = EntityType.Feat });
        return feats.ToDictionary(f => f.Id);
    }

    private async Task LoadAbilityScoreIncreases(NpgsqlConnection conn, Dictionary<Guid, FeatDbModel> feats)
    {
        var sql = @"SELECT entity_id, ability, amount 
                    FROM ability_score_increase 
                    WHERE entity_id = ANY(@Ids);";

        var abilityIncreases = await conn.QueryAsync(sql, new { Ids = feats.Keys.ToArray() });

        foreach (var asi in abilityIncreases)
        {
            if (feats.TryGetValue((Guid)asi.entity_id, out var feat))
            {
                feat.AbilityScoreIncreases ??= new List<AbilityScoreIncreaseModel>();
                feat.AbilityScoreIncreases.Add(new AbilityScoreIncreaseModel
                {
                    Ability = asi.ability,
                    Amount = asi.amount
                });
            }
        }
    }

    private async Task LoadChoices(NpgsqlConnection conn, Dictionary<Guid, FeatDbModel> feats)
    {
        var sqlChoices = @"SELECT id, entity_id, description, number_to_choose, type 
                           FROM choice 
                           WHERE entity_id = ANY(@Ids);";

        var choices = await conn.QueryAsync(sqlChoices, new { Ids = feats.Keys.ToArray() });

        if (!choices.Any())
            return;

        var sqlOptions = @"SELECT choice_id, value 
                           FROM choice_option 
                           WHERE choice_id = ANY(@ChoiceIds);";

        var options = await conn.QueryAsync(sqlOptions, new { ChoiceIds = choices.Select(c => (int)c.id).ToArray() });

        var optionsByChoice = options.GroupBy(o => (int)o.choice_id)
                                     .ToDictionary(g => g.Key, g => g.Select(x => (string)x.value).ToList());

        foreach (var choice in choices)
        {
            if (!feats.TryGetValue((Guid)choice.entity_id, out var feat))
                continue;

            if ((string)choice.type == "Effect")
            {
                feat.EffectChoices ??= new List<ChoiceModel<string>>();
                feat.EffectChoices.Add(new ChoiceModel<string>
                {
                    Description = choice.description,
                    NumberToChoose = choice.number_to_choose,
                    Options = optionsByChoice.GetValueOrDefault((int)choice.id, new List<string>())
                });
            }
            else if ((string)choice.type == "AbilityScoreIncrease")
            {
                feat.AbilityScoreIncreaseChoices ??= new List<ChoiceModel<AbilityScoreIncreaseModel>>();
                feat.AbilityScoreIncreaseChoices.Add(new ChoiceModel<AbilityScoreIncreaseModel>
                {
                    Description = choice.description,
                    NumberToChoose = choice.number_to_choose,
                    Options = optionsByChoice.GetValueOrDefault((int)choice.id, new List<string>())
                        .Select(o =>
                        {
                            var parts = o.Split('+');
                            return new AbilityScoreIncreaseModel { Ability = parts[0], Amount = int.Parse(parts[1]) };
                        }).ToList()
                });
            }
        }
    }

}