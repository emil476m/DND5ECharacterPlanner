using infrastructure.Models.Feats;

namespace infrastructure.Mappers;

public static class FeatMapper
{
    public static FeatDbModel ToDbModel(this FeatModel model)
    {
        return new FeatDbModel()
        {
            Effect = model.Effect,
            AbilityScoreIncreases = model.AbilityScoreIncreases,
            AbilityScoreIncreaseChoices = model.AbilityScoreIncreaseChoices
        };
    }

    public static FeatModel ToFeatModel(this FeatDbModel model)
    {
        return new FeatModel()
        {
            Effect = model.Effect,
            AbilityScoreIncreases = model.AbilityScoreIncreases,
            AbilityScoreIncreaseChoices = model.AbilityScoreIncreaseChoices
        };
    }
}