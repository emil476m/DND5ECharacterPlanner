using Core.Models.Feats;
using infrastructure.DatabaseModels.Feats;

namespace infrastructure.Mappers;

public static class FeatMapper
{
    public static FeatDbModel ToDbModel(this FeatModel model)
    {
        return new FeatDbModel()
        {
            //entity model
            Id = model.Id,
            Name = model.Name,
            IsOfficial = model.IsOfficial,
            IsPublic = model.IsPublic,
            CreatedAt = model.CreatedAt,
            CreatedByUserId = model.CreatedByUserId,
            UsedRuleset = model.UsedRuleset,
            Type = model.Type,
            
            //feat model
            Effect = model.Effect,
            EffectChoices = model.EffectChoices,
            AbilityScoreIncreases = model.AbilityScoreIncreases,
            AbilityScoreIncreaseChoices = model.AbilityScoreIncreaseChoices
        };
    }

    public static FeatModel ToFeatModel(this FeatDbModel model)
    {
        return new FeatModel()
        {
            //entity model
            Id = model.Id,
            Name = model.Name,
            IsOfficial = model.IsOfficial,
            IsPublic = model.IsPublic,
            CreatedAt = model.CreatedAt,
            CreatedByUserId = model.CreatedByUserId,
            UsedRuleset = model.UsedRuleset,
            Type = model.Type,
            
            //feat model
            Effect = model.Effect,
            EffectChoices = model.EffectChoices,
            AbilityScoreIncreases = model.AbilityScoreIncreases,
            AbilityScoreIncreaseChoices = model.AbilityScoreIncreaseChoices
        };
    }
}