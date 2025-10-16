using Core.Models.Items;
using infrastructure.DatabaseModels.Items;

namespace infrastructure.Mappers;

public static class ItemMapper
{
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
            RequiredProficiencies = dbModel.RequiredProficiencies,
            //Armor properties
            ArmorClass = armorModel.ArmorClass,
            MaxDexBonus = armorModel.MaxDexBonus,
            RequiresProficiency = armorModel.RequiresProficiency,
            ProficiencyType = armorModel.ProficiencyType,
            StrengthRequirement = armorModel.StrengthRequirement,
            IsShield = armorModel.IsShield,
            StealthDisadvantage = armorModel.StealthDisadvantage,
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
            RequiredProficiencies = dbModel.RequiredProficiencies,
            //Armor properties
            ArmorClass = dbModel.ArmorClass,
            MaxDexBonus = dbModel.MaxDexBonus,
            RequiresProficiency = dbModel.RequiresProficiency,
            ProficiencyType = dbModel.ProficiencyType,
            StrengthRequirement = dbModel.StrengthRequirement,
            IsShield = dbModel.IsShield,
            StealthDisadvantage = dbModel.StealthDisadvantage,
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
            RequiredProficiencies = dbModel.RequiredProficiencies,
            //Armor properties
            Denomination = currencyModel.Denomination,
            Amount = currencyModel.Amount,
        };
    }
}