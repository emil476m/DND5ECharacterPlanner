using Core.Enums;
using Core.Interfaces;
using Core.Models.Items;
using Dapper;
using infrastructure.DatabaseModels.Items;
using infrastructure.Mappers;
using Npgsql;

namespace infrastructure.Implementations;

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
               i.cost AS {nameof(ItemDbModel.CostInGold)}
        FROM dnd_entity e
        JOIN item i ON e.id = i.id
        WHERE e.entity_type = @EntityType;";

        var baseItems =
            (await conn.QueryAsync<ItemDbModel>(sqlBase, new { EntityType = EntityType.Item })).ToDictionary(i => i.Id);
        
        if (baseItems.Count == 0)
            return [];
        
        var results = new List<ItemModel>();
        
        async Task AddSubItemsAsync<T>(string sql, Func<T, Guid> idSelector, Func<T , ItemDbModel, ItemModel> mapper)
        {
            var subItems = await conn.QueryAsync<T>(sql);
            foreach (var s in subItems)
            {
                var id = idSelector(s);
                if (baseItems.TryGetValue(id, out var baseItem))
                {
                    results.Add(mapper(s, baseItem));
                }
            }
        }

        await AddSubItemsAsync<ArmorDbModel>(@$"SELECT 
                                                    id AS {nameof(ArmorDbModel.Id)},
                                                    armor_class AS {nameof(ArmorDbModel.ArmorClass)},
                                                    max_dex_bonus AS {nameof(ArmorDbModel.MaxDexBonus)}, 
                                                    requires_proficiency AS {nameof(ArmorDbModel.RequiresProficiency)},    
                                                    proficiency_type AS {nameof(ArmorDbModel.ProficiencyType)}, 
                                                    strength_requirement AS {nameof(ArmorDbModel.StrengthRequirement)},   
                                                    is_shield AS {nameof(ArmorDbModel.IsShield)},    
                                                    stealth_disadvantage AS {nameof(ArmorDbModel.StealthDisadvantage)}
                                                    FROM armor;", db => db.Id, (db, baseItem) => db.ToArmorModel(baseItem));
        
        await AddSubItemsAsync<CurrencyDbModel>(@$"SELECT
                                                        id AS {nameof(CurrencyDbModel.Id)},
                                                        denomination {nameof(CurrencyDbModel.Denomination)},
                                                        amount AS {nameof(CurrencyDbModel.Amount)}
                                                        FROM currency;", db => db.Id, (db, baseItem) => db.ToCurrencyModel(baseItem));
        
        await AddSubItemsAsync<WeaponDbModel>($@"SELECT
                                                      id AS {nameof(WeaponDbModel.Id)},
                                                      damage AS {nameof(WeaponDbModel.Damage)},
                                                      damage_type AS {nameof(WeaponDbModel.DamageType)},
                                                      weapon_type AS {nameof(WeaponDbModel.WeaponType)},
                                                      properties AS {nameof(WeaponDbModel.Properties)},
                                                      range AS {nameof(WeaponDbModel.Range)}
                                                      FROM weapon;
                                                      ", db => db.Id, (db, baseItem) => db.ToWeaponModel(baseItem));
        
        return results;
    }
    


    

    public async Task<ItemModel?> GetItemById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ItemModel> CreateArmor(ArmorModel armor)
    {
        throw new NotImplementedException();
    }

    public async Task<ItemModel> CreateWeapon(WeaponModel weapon)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> CreateTool(ToolModel tool)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> CreateCurrency(CurrencyModel currency)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> CreateWondrous(WondrousItemModel wondrous)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateArmor(ArmorModel armor)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateWeapon(WeaponModel weapon)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateTool(ToolModel tool)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateCurrency(CurrencyModel currency)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateWondrous(WondrousItemModel wondrous)
    {
        throw new NotImplementedException();
    }
}