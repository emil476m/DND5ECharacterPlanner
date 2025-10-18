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
            RequiredProficiencies = model.RequiredProficiencies,
            // Armor
            ArmorClass = model.ArmorClass,
            MaxDexBonus = model.MaxDexBonus,
            RequiresProficiency = model.RequiresProficiency,
            ProficiencyType = model.ProficiencyType,
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
            RequiredProficiencies = model.RequiredProficiencies,
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
            RequiredProficiencies = model.RequiredProficiencies,
            // Weapon
            Damage = model.Damage,
            DamageType = model.DamageType,
            WeaponType = model.WeaponType,
            Properties = model.Properties,
            Range = model.Range,
        };
    }
}