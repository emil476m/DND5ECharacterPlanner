using Core.Models.Items;
using Infrastructure.DatabaseModels.Items;

namespace Infrastructure.Mappers;

public static class ItemMapper
{
    public static GenericItemModel ToGenericItemModel(this ItemDbModel dbModel)
    {
        return new GenericItemModel
        {
            //Entity properties
            Id = dbModel.Id,
            Name = dbModel.Name,
            IsPublic = dbModel.IsPublic,
            IsOfficial = dbModel.IsOfficial,
            CreatedByUserId = dbModel.CreatedByUserId,
            CreatedAt = dbModel.CreatedAt,
            UsedRuleset = dbModel.UsedRuleset,
            Type = dbModel.Type,
            //Item properties
            Category = dbModel.Category,
            Description = dbModel.Description,
            Weight = dbModel.Weight,
            CostInGold = dbModel.CostInGold,
            RequiredProficiency = dbModel.RequiredProficiency
        };
    }

    public static ArmorModel ToArmorModel(this ArmorDbModel armorModel, ItemDbModel dbModel)
    {
        return new ArmorModel
        {
            //Entity properties
            Id = dbModel.Id,
            Name = dbModel.Name,
            IsPublic = dbModel.IsPublic,
            IsOfficial = dbModel.IsOfficial,
            CreatedByUserId = dbModel.CreatedByUserId,
            CreatedAt = dbModel.CreatedAt,
            UsedRuleset = dbModel.UsedRuleset,
            Type = dbModel.Type,
            //Item properties
            Category = dbModel.Category,
            Description = dbModel.Description,
            Weight = dbModel.Weight,
            CostInGold = dbModel.CostInGold,
            RequiredProficiency = dbModel.RequiredProficiency,
            //Armor properties
            ArmorClass = armorModel.ArmorClass,
            MaxDexBonus = armorModel.MaxDexBonus,
            StrengthRequirement = armorModel.StrengthRequirement,
            IsShield = armorModel.IsShield,
            StealthDisadvantage = armorModel.StealthDisadvantage
        };
    }

    public static ArmorDbModel ToArmorDbModel(this ArmorModel dbModel)
    {
        return new ArmorDbModel
        {
            //Entity properties
            Id = dbModel.Id,
            Name = dbModel.Name,
            IsPublic = dbModel.IsPublic,
            IsOfficial = dbModel.IsOfficial,
            CreatedByUserId = dbModel.CreatedByUserId,
            CreatedAt = dbModel.CreatedAt,
            UsedRuleset = dbModel.UsedRuleset,
            Type = dbModel.Type,
            //Item properties
            Category = dbModel.Category,
            Description = dbModel.Description,
            Weight = dbModel.Weight,
            CostInGold = dbModel.CostInGold,
            RequiredProficiency = dbModel.RequiredProficiency,
            //Armor properties
            ArmorClass = dbModel.ArmorClass,
            MaxDexBonus = dbModel.MaxDexBonus,
            StrengthRequirement = dbModel.StrengthRequirement,
            IsShield = dbModel.IsShield,
            StealthDisadvantage = dbModel.StealthDisadvantage
        };
    }

    public static CurrencyModel ToCurrencyModel(this CurrencyDbModel currencyModel, ItemDbModel dbModel)
    {
        return new CurrencyModel
        {
            //Entity properties
            Id = dbModel.Id,
            Name = dbModel.Name,
            IsPublic = dbModel.IsPublic,
            IsOfficial = dbModel.IsOfficial,
            CreatedByUserId = dbModel.CreatedByUserId,
            CreatedAt = dbModel.CreatedAt,
            UsedRuleset = dbModel.UsedRuleset,
            Type = dbModel.Type,
            //Item properties
            Category = dbModel.Category,
            Description = dbModel.Description,
            Weight = dbModel.Weight,
            CostInGold = dbModel.CostInGold,
            RequiredProficiency = dbModel.RequiredProficiency,
            //Currency properties
            Denomination = currencyModel.Denomination,
            Amount = currencyModel.Amount
        };
    }

    public static WeaponModel ToWeaponModel(this WeaponDbModel weaponModel, ItemDbModel dbModel)
    {
        return new WeaponModel
        {
            //Entity properties
            Id = dbModel.Id,
            Name = dbModel.Name,
            IsPublic = dbModel.IsPublic,
            IsOfficial = dbModel.IsOfficial,
            CreatedByUserId = dbModel.CreatedByUserId,
            CreatedAt = dbModel.CreatedAt,
            UsedRuleset = dbModel.UsedRuleset,
            Type = dbModel.Type,
            //Item properties
            Category = dbModel.Category,
            Description = dbModel.Description,
            Weight = dbModel.Weight,
            CostInGold = dbModel.CostInGold,
            RequiredProficiency = dbModel.RequiredProficiency,
            //Weapon properties
            Damage = weaponModel.Damage,
            DamageType = weaponModel.DamageType,
            WeaponType = weaponModel.WeaponType,
            Properties = weaponModel.Properties,
            Range = weaponModel.Range
        };
    }

    public static WondrousItemModel ToWondrousItemModel(this WondrousItemDbModel wondrousItemModel, ItemDbModel dbModel)
    {
        return new WondrousItemModel
        {
            //Entity properties
            Id = dbModel.Id,
            Name = dbModel.Name,
            IsPublic = dbModel.IsPublic,
            IsOfficial = dbModel.IsOfficial,
            CreatedByUserId = dbModel.CreatedByUserId,
            CreatedAt = dbModel.CreatedAt,
            UsedRuleset = dbModel.UsedRuleset,
            Type = dbModel.Type,
            //Item properties
            Category = dbModel.Category,
            Description = dbModel.Description,
            Weight = dbModel.Weight,
            CostInGold = dbModel.CostInGold,
            RequiredProficiency = dbModel.RequiredProficiency,
            //Wondrous Item properties
            Rarity = wondrousItemModel.Rarity,
            RequiresAttunement = wondrousItemModel.RequiresAttunement
        };
    }
}