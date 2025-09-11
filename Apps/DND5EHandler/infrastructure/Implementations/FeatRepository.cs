using Dapper;
using infrastructure.Interfaces;
using infrastructure.Mappers;
using infrastructure.Models.Feats;
using Npgsql;

namespace infrastructure.Implementations;

public class FeatRepository : IRepository<FeatModel>
{
    
    private readonly NpgsqlDataSource _dataSource;

    public FeatRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    
    public Task<FeatModel> GetResult(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

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
    

    
    
    public Task<FeatModel> Update(Guid id, FeatModel item)
    {
        throw new NotImplementedException();
    }
}