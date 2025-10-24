using Core.Enums;
using Core.Interfaces;
using Core.Models.Items;
using Core.Models.Miscellaneous;
using Dapper;
using Infrastructure.DatabaseModels.Items;
using Infrastructure.Mappers;
using Npgsql;

namespace Infrastructure.Implementations;

public class ItemRepository : IItemRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public ItemRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    /**
     * Methods that gets a list of all items and its subtypes
     */
    public async Task<IEnumerable<ItemModel>> GetAllItems()
    {
        using var conn = await _dataSource.OpenConnectionAsync();

        // gets base item and entity data

        const string sqlBase = @$"
        SELECT 
               e.id AS {nameof(ItemDbModel.Id)},
               e.name AS {nameof(ItemDbModel.Name)},
               e.is_public AS {nameof(ItemDbModel.IsPublic)}, 
               e.is_official AS {nameof(ItemDbModel.IsOfficial)},
               e.created_by_user_id AS {nameof(ItemDbModel.CreatedByUserId)}, 
               e.created_at AS {nameof(ItemDbModel.CreatedAt)},
               e.used_ruleset AS {nameof(ItemDbModel.UsedRuleset)}, 
               e.entity_type AS {nameof(ItemDbModel.Type)},
               i.item_category AS {nameof(ItemDbModel.Category)}, 
               i.description AS {nameof(ItemDbModel.Description)}, 
               i.weight AS {nameof(ItemDbModel.Weight)}, 
               i.cost AS {nameof(ItemDbModel.CostInGold)},
               p.id AS {nameof(ProficiencyModel.Id)},
               p.name AS {nameof(ProficiencyModel.Name)}
        FROM dnd_entity e
        JOIN item i ON e.id = i.id
        LEFT JOIN proficiency p ON i.proficiency = p.id
        WHERE e.entity_type = @EntityType;";

        var baseItems = (await conn.QueryAsync<ItemDbModel, ProficiencyModel, ItemDbModel>(
            sqlBase,
            (item, proficiency) =>
            {
                item.RequiredProficiency = proficiency;
                return item;
            },
            new { EntityType = EntityType.Item },
            splitOn: nameof(ProficiencyModel.Id)
        )).ToDictionary(i => i.Id);

        if (baseItems.Count == 0)
            return [];

        var results = new List<ItemModel>();

        async Task AddSubItemsAsync<T>(string sql, Func<T, Guid> idSelector, Func<T, ItemDbModel, ItemModel> mapper)
        {
            var subItems = await conn.QueryAsync<T>(sql);
            foreach (var s in subItems)
            {
                var id = idSelector(s);
                if (baseItems.TryGetValue(id, out var baseItem)) results.Add(mapper(s, baseItem));
            }
        }

        await AddSubItemsAsync<ArmorDbModel>(@$"SELECT 
                                                    id AS {nameof(ArmorDbModel.Id)},
                                                    armor_class AS {nameof(ArmorDbModel.ArmorClass)},
                                                    max_dex_bonus AS {nameof(ArmorDbModel.MaxDexBonus)},
                                                    strength_requirement AS {nameof(ArmorDbModel.StrengthRequirement)},   
                                                    is_shield AS {nameof(ArmorDbModel.IsShield)},    
                                                    stealth_disadvantage AS {nameof(ArmorDbModel.StealthDisadvantage)}
                                                    FROM armor;", db => db.Id,
            (db, baseItem) => db.ToArmorModel(baseItem));

        await AddSubItemsAsync<CurrencyDbModel>(@$"SELECT
                                                        id AS {nameof(CurrencyDbModel.Id)},
                                                        denomination AS {nameof(CurrencyDbModel.Denomination)},
                                                        amount AS {nameof(CurrencyDbModel.Amount)}
                                                        FROM currency;", db => db.Id,
            (db, baseItem) => db.ToCurrencyModel(baseItem));

        await AddSubItemsAsync<WeaponDbModel>($@"SELECT
                                                      id AS {nameof(WeaponDbModel.Id)},
                                                      damage AS {nameof(WeaponDbModel.Damage)},
                                                      damage_type AS {nameof(WeaponDbModel.DamageType)},
                                                      weapon_type AS {nameof(WeaponDbModel.WeaponType)},
                                                      properties AS {nameof(WeaponDbModel.Properties)},
                                                      range AS {nameof(WeaponDbModel.Range)}
                                                      FROM weapon;
                                                      ", db => db.Id, (db, baseItem) => db.ToWeaponModel(baseItem));

        await AddSubItemsAsync<WondrousItemDbModel>(@$"SELECT
                                                            id AS {nameof(WondrousItemDbModel.Id)},
                                                            rarity AS {nameof(WondrousItemDbModel.Rarity)},
                                                            attunement_required AS {nameof(WondrousItemDbModel.RequiresAttunement)}
                                                            FROM wondrous_item;", db => db.Id,
            (db, baseItem) => db.ToWondrousItemModel(baseItem));

        // Adds leftover base items, with no subtype
        foreach (var remaining in baseItems.Values)
            if (!results.Any(r => r.Id == remaining.Id))
                results.Add(remaining.ToGenericItemModel());

        return results;
    }


    public async Task<ItemModel?> GetItemById(Guid id)
    {
        using var conn = await _dataSource.OpenConnectionAsync();

        const string sqlBase = $@"
            SELECT 
               e.id AS {nameof(ItemDbModel.Id)},
               e.name AS {nameof(ItemDbModel.Name)},
               e.is_public AS {nameof(ItemDbModel.IsPublic)}, 
               e.is_official AS {nameof(ItemDbModel.IsOfficial)},
               e.created_by_user_id AS {nameof(ItemDbModel.CreatedByUserId)}, 
               e.created_at AS {nameof(ItemDbModel.CreatedAt)},
               e.used_ruleset AS {nameof(ItemDbModel.UsedRuleset)}, 
               e.entity_type AS {nameof(ItemDbModel.Type)},
               i.item_category AS {nameof(ItemDbModel.Category)}, 
               i.description AS {nameof(ItemDbModel.Description)}, 
               i.weight AS {nameof(ItemDbModel.Weight)}, 
               i.cost AS {nameof(ItemDbModel.CostInGold)},
               p.id AS {nameof(ProficiencyModel.Id)},
               p.name AS {nameof(ProficiencyModel.Name)}
            FROM dnd_entity e
            JOIN item i ON e.id = i.id
            LEFT JOIN proficiency p ON i.proficiency = p.id
            WHERE e.entity_type = @EntityType AND e.id = @Id
            LIMIT 1;";

        var baseItem = (await conn.QueryAsync<ItemDbModel, ProficiencyModel, ItemDbModel>(
            sqlBase,
            (item, proficiency) =>
            {
                item.RequiredProficiency = proficiency;
                return item;
            },
            new { EntityType = EntityType.Item, Id = id },
            splitOn: nameof(ProficiencyModel.Id)
        )).FirstOrDefault();

        if (baseItem == null)
            return null;

        // Check subtypes 
        // switch case could be used here, but ill add it if I add more subtypes
        if (baseItem.Category == ItemCategory.ArmorAndShields)
        {
            var armor = await conn.QuerySingleOrDefaultAsync<ArmorDbModel>($@"
            SELECT 
            id AS {nameof(ArmorDbModel.Id)},
            armor_class AS {nameof(ArmorDbModel.ArmorClass)},
            max_dex_bonus AS {nameof(ArmorDbModel.MaxDexBonus)},
            strength_requirement AS {nameof(ArmorDbModel.StrengthRequirement)},   
            is_shield AS {nameof(ArmorDbModel.IsShield)},    
            stealth_disadvantage AS {nameof(ArmorDbModel.StealthDisadvantage)}
            FROM armor
            WHERE id = @Id;", new { Id = id });

            if (armor != null) return armor.ToArmorModel(baseItem);
        }

        if (baseItem.Category == ItemCategory.Currency)
        {
            var currency = await conn.QuerySingleOrDefaultAsync<CurrencyDbModel>($@"
            SELECT
            id AS {nameof(CurrencyDbModel.Id)},
            denomination AS {nameof(CurrencyDbModel.Denomination)},
            amount AS {nameof(CurrencyDbModel.Amount)}
            FROM currency
            WHERE id = @Id;", new { Id = id });

            if (currency != null) return currency.ToCurrencyModel(baseItem);
        }

        if (baseItem.Category == ItemCategory.Weapon)
        {
            var weapon = await conn.QuerySingleOrDefaultAsync<WeaponDbModel>($@"
            SELECT
            id AS {nameof(WeaponDbModel.Id)},
            damage AS {nameof(WeaponDbModel.Damage)},
            damage_type AS {nameof(WeaponDbModel.DamageType)},
            weapon_type AS {nameof(WeaponDbModel.WeaponType)},
            properties AS {nameof(WeaponDbModel.Properties)},
            range AS {nameof(WeaponDbModel.Range)}
            FROM weapon
            WHERE id = @Id;", new { Id = id });

            if (weapon != null) return weapon.ToWeaponModel(baseItem);
        }

        if (baseItem.Category == ItemCategory.WondrousItem)
        {
            var wondrous = await conn.QuerySingleOrDefaultAsync<WondrousItemDbModel>($@"
            SELECT
            id AS {nameof(WondrousItemDbModel.Id)},
            rarity AS {nameof(WondrousItemDbModel.Rarity)},
            attunement_required AS {nameof(WondrousItemDbModel.RequiresAttunement)}
            FROM wondrous_item                                                
            WHERE id = @Id;", new { Id = id });

            if (wondrous != null) return wondrous.ToWondrousItemModel(baseItem);
        }

        return baseItem.ToGenericItemModel();
    }

    public async Task<bool> DeleteItem(Guid id)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        var sql = "DELETE FROM dnd_entity WHERE id = @Id AND entity_type = @type;";
        return await conn.ExecuteAsync(sql, new { Id = id, type = EntityType.Item }) > 0;
    }


    public async Task<ItemModel> CreateArmor(ArmorModel armor)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await CreateBaseEntityAndItem(armor, conn, tx);

            await conn.ExecuteAsync(@"
        INSERT INTO armor (id, armor_class, max_dex_bonus, strength_requirement, is_shield, stealth_disadvantage)
        VALUES (@Id, @ArmorClass, @MaxDexBonus, @StrengthRequirement, @IsShield, @StealthDisadvantage);",
                new
                {
                    armor.Id,
                    armor.ArmorClass,
                    armor.MaxDexBonus,
                    armor.StrengthRequirement,
                    armor.IsShield,
                    armor.StealthDisadvantage
                }, tx);

            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not create armor", e);
        }

        return armor;
    }

    public async Task<ItemModel> CreateWeapon(WeaponModel weapon)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await CreateBaseEntityAndItem(weapon, conn, tx);

            await conn.ExecuteAsync(@"
            INSERT INTO weapon (id, damage, damage_type, weapon_type, properties, range)
            VALUES (@Id, @Damage, @DamageType, @WeaponType, @Properties, @Range);",
                new
                {
                    weapon.Id,
                    weapon.Damage,
                    weapon.DamageType,
                    weapon.WeaponType,
                    weapon.Properties,
                    weapon.Range
                }, tx);

            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not create weapon", e);
        }

        return weapon;
    }

    public async Task<ItemModel> CreateGenericItem(ItemModel item)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await CreateBaseEntityAndItem(item, conn, tx);
            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not create item", e);
        }

        return item;
    }

    public async Task<ItemModel> CreateCurrency(CurrencyModel currency)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await CreateBaseEntityAndItem(currency, conn, tx);

            await conn.ExecuteAsync(@"
        INSERT INTO currency (id, denomination, amount)
        VALUES (@Id, @Denomination, @Amount);",
                new
                {
                    currency.Id,
                    currency.Denomination,
                    currency.Amount
                }, tx);

            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not create currency", e);
        }

        return currency;
    }

    public async Task<ItemModel> CreateWondrous(WondrousItemModel wondrous)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await CreateBaseEntityAndItem(wondrous, conn, tx);

            await conn.ExecuteAsync(@"
        INSERT INTO wondrous_item (id, rarity, attunement_required)
        VALUES (@Id, @Rarity, @RequiresAttunement);",
                new
                {
                    wondrous.Id,
                    wondrous.Rarity,
                    wondrous.RequiresAttunement
                }, tx);

            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not create wondrous item", e);
        }

        return wondrous;
    }

    public async Task<ItemModel> UpdateArmor(ArmorModel armor)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await UpdateBaseEntityAndItem(armor, conn, tx);

            await conn.ExecuteAsync(@"
                    UPDATE armor
                    SET armor_class = @ArmorClass, max_dex_bonus = @MaxDexBonus, strength_requirement = @StrengthRequirement,
                        is_shield = @IsShield, stealth_disadvantage = @StealthDisadvantage
                    WHERE id = @Id;",
                new
                {
                    armor.Id,
                    armor.ArmorClass,
                    armor.MaxDexBonus,
                    armor.StrengthRequirement,
                    armor.IsShield,
                    armor.StealthDisadvantage
                }, tx);

            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not update armor", e);
        }

        return armor;
    }

    public async Task<ItemModel> UpdateWeapon(WeaponModel weapon)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await UpdateBaseEntityAndItem(weapon, conn, tx);

            await conn.ExecuteAsync(@"
                    UPDATE weapon
                    SET damage = @Damage, damage_type = @DamageType, weapon_type = @WeaponType, properties = @Properties, range = @Range
                    WHERE id = @Id;",
                new
                {
                    weapon.Id,
                    weapon.Damage,
                    weapon.DamageType,
                    weapon.WeaponType,
                    weapon.Properties,
                    weapon.Range
                }, tx);

            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not update weapon", e);
        }

        return weapon;
    }

    public async Task<ItemModel> UpdateGenericItem(ItemModel item)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await UpdateBaseEntityAndItem(item, conn, tx);
            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not update item", e);
        }

        return item;
    }

    public async Task<ItemModel> UpdateCurrency(CurrencyModel currency)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await UpdateBaseEntityAndItem(currency, conn, tx);

            await conn.ExecuteAsync(@"
                    UPDATE currency
                    SET denomination = @Denomination, amount = @Amount
                    WHERE id = @Id;",
                new
                {
                    currency.Id,
                    currency.Denomination,
                    currency.Amount
                }, tx);

            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not update currency", e);
        }

        return currency;
    }

    public async Task<ItemModel> UpdateWondrous(WondrousItemModel wondrous)
    {
        using var conn = await _dataSource.OpenConnectionAsync();
        using var tx = await conn.BeginTransactionAsync();

        try
        {
            //Creates base entity and item
            await UpdateBaseEntityAndItem(wondrous, conn, tx);

            await conn.ExecuteAsync(@"
                    UPDATE wondrous_item
                    SET rarity = @Rarity, attunement_required = @RequiresAttunement
                    WHERE id = @Id;",
                new
                {
                    wondrous.Id,
                    wondrous.Rarity,
                    wondrous.RequiresAttunement
                }, tx);

            await tx.CommitAsync();
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            throw new Exception("Could not update wondrous item", e);
        }

        return wondrous;
    }


    private async Task CreateBaseEntityAndItem(ItemModel item, NpgsqlConnection conn, NpgsqlTransaction transaction)
    {
        const string sqlEntity = @"
            INSERT INTO dnd_entity (id, name, is_public, is_official, created_by_user_id, created_at, used_ruleset, entity_type)
            VALUES (@Id, @Name, @IsPublic, @IsOfficial, @CreatedByUserId, @CreatedAt, @UsedRuleset, @Type);";

        await conn.ExecuteAsync(sqlEntity, new
        {
            item.Id,
            item.Name,
            item.IsPublic,
            item.IsOfficial,
            item.CreatedByUserId,
            item.CreatedAt,
            item.UsedRuleset,
            Type = EntityType.Item
        }, transaction);

        const string sqlItem = @"
            INSERT INTO item (id, item_category, description, weight, cost, proficiency)
            VALUES (@Id, @Category, @Description, @Weight, @CostInGold, @ProficiencyId);";

        await conn.ExecuteAsync(sqlItem, new
        {
            item.Id,
            item.Category,
            item.Description,
            item.Weight,
            item.CostInGold,
            ProficiencyId = item.RequiredProficiency?.Id
        }, transaction);
    }

    private async Task UpdateBaseEntityAndItem(ItemModel item, NpgsqlConnection conn, NpgsqlTransaction transaction)
    {
        const string sqlEntity = @"
            UPDATE dnd_entity
            SET name = @Name,
                is_public = @IsPublic,
                is_official = @IsOfficial,
                used_ruleset = @UsedRuleset
            WHERE id = @Id AND entity_type = @Type;";

        await conn.ExecuteAsync(sqlEntity, new
        {
            item.Id,
            item.Name,
            item.IsPublic,
            item.IsOfficial,
            item.UsedRuleset,
            Type = EntityType.Item
        }, transaction);

        const string sqlItem = @"
            UPDATE item
            SET item_category = @Category,
                description = @Description,
                weight = @Weight,
                cost = @CostInGold,
                proficiency = @ProficiencyId
            WHERE id = @Id;";

        await conn.ExecuteAsync(sqlItem, new
        {
            item.Id,
            item.Category,
            item.Description,
            item.Weight,
            item.CostInGold,
            ProficiencyId = item.RequiredProficiency?.Id
        }, transaction);
    }
}