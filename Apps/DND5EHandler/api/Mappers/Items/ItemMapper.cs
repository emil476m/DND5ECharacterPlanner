using api.TransferModels.Items;
using Core.Models.Items;

namespace api.Mappers.Items;

public static class ItemMapper
{
    public static ItemDto ToItemDto(this ItemModel model)
    {
        return model switch
        {
            ArmorModel a => a.ToArmorDto(),
            CurrencyModel c => c.ToCurrencyDto(),
            WeaponModel w => w.ToWeaponDto(),
            WondrousItemModel wi => wi.ToWondrousItemDto(),
            GenericItemModel gi => gi.ToGenericItemDto(),
            _ => throw new NotSupportedException($"Unsupported item subtype: {model.GetType().Name}")
        };
    }

    public static ArmorDto ToArmorDto(this ArmorModel model)
    {
        return new ArmorDto
        {
            // DndEntity
            Id = model.Id,
            Name = model.Name,
            IsPublic = model.IsPublic,
            IsOfficial = model.IsOfficial,
            CreatedByUserId = model.CreatedByUserId,
            CreatedAt = model.CreatedAt,
            UsedRuleset = model.UsedRuleset,
            Type = model.Type,
            // Item
            Category = model.Category,
            Description = model.Description,
            Weight = model.Weight,
            CostInGold = model.CostInGold,
            RequiredProficiency = model.RequiredProficiency,
            // Armor
            ArmorClass = model.ArmorClass,
            MaxDexBonus = model.MaxDexBonus,
            StrengthRequirement = model.StrengthRequirement,
            IsShield = model.IsShield,
            StealthDisadvantage = model.StealthDisadvantage
        };
    }

    public static CurrencyDto ToCurrencyDto(this CurrencyModel model)
    {
        return new CurrencyDto
        {
            // DndEntity
            Id = model.Id,
            Name = model.Name,
            IsPublic = model.IsPublic,
            IsOfficial = model.IsOfficial,
            CreatedByUserId = model.CreatedByUserId,
            CreatedAt = model.CreatedAt,
            UsedRuleset = model.UsedRuleset,
            Type = model.Type,
            // Item
            Category = model.Category,
            Description = model.Description,
            Weight = model.Weight,
            CostInGold = model.CostInGold,
            RequiredProficiency = model.RequiredProficiency,
            // Currency
            Denomination = model.Denomination,
            Amount = model.Amount
        };
    }
    
    public static WeaponDto ToWeaponDto(this WeaponModel model)
    {
        return new WeaponDto
        {
            // DndEntity
            Id = model.Id,
            Name = model.Name,
            IsPublic = model.IsPublic,
            IsOfficial = model.IsOfficial,
            CreatedByUserId = model.CreatedByUserId,
            CreatedAt = model.CreatedAt,
            UsedRuleset = model.UsedRuleset,
            Type = model.Type,
            // Item
            Category = model.Category,
            Description = model.Description,
            Weight = model.Weight,
            CostInGold = model.CostInGold,
            RequiredProficiency = model.RequiredProficiency,
            // Weapon
            Damage = model.Damage,
            DamageType = model.DamageType,
            WeaponType = model.WeaponType,
            Properties = model.Properties,
            Range = model.Range,
        };
    }
    
    public static WondrousItemDto ToWondrousItemDto(this WondrousItemModel model)
    {
        return new WondrousItemDto
        {
            // DndEntity
            Id = model.Id,
            Name = model.Name,
            IsPublic = model.IsPublic,
            IsOfficial = model.IsOfficial,
            CreatedByUserId = model.CreatedByUserId,
            CreatedAt = model.CreatedAt,
            UsedRuleset = model.UsedRuleset,
            Type = model.Type,
            // Item
            Category = model.Category,
            Description = model.Description,
            Weight = model.Weight,
            CostInGold = model.CostInGold,
            RequiredProficiency = model.RequiredProficiency,
            // Weapon
            Rarity = model.Rarity,
            RequiresAttunement = model.RequiresAttunement,
        };
    }
    
    public static GenericItemDto ToGenericItemDto(this GenericItemModel dto)
    {
        return new GenericItemDto
        {
            // DndEntity
            Id = dto.Id,
            Name = dto.Name,
            IsPublic = dto.IsPublic,
            IsOfficial = dto.IsOfficial,
            CreatedByUserId = dto.CreatedByUserId,
            CreatedAt = dto.CreatedAt,
            UsedRuleset = dto.UsedRuleset,
            Type = dto.Type,
            // Item
            Category = dto.Category,
            Description = dto.Description,
            Weight = dto.Weight,
            CostInGold = dto.CostInGold,
            RequiredProficiency = dto.RequiredProficiency,
        };
    }
}