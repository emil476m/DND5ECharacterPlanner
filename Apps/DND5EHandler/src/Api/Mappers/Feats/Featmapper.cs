using Api.TransferModels.Feats;
using Core.Enums;
using Core.Models.Feats;
using Core.Models.Miscellaneous;

namespace Api.Mappers;

public static class FeatMapper
{
    public static FeatDto ToFeatDto(this FeatModel model)
    {
        return new FeatDto
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


    public static FeatModel ToFeatModel(this FeatCreateDto dto)
    {
        return new FeatModel
        {
            //EntityModel
            Name = dto.Name,
            IsPublic = dto.IsPublic,
            UsedRuleset = dto.UsedRuleset,
            Type = EntityType.Feat,

            //FeatModel
            Effect = dto.Effect,
            EffectChoices = dto.EffectChoices,
            AbilityScoreIncreases = dto.AbilityScoreIncreases ?? new List<AbilityScoreIncreaseModel>(),
            AbilityScoreIncreaseChoices =
                dto.AbilityScoreIncreaseChoices ?? new List<ChoiceModel<AbilityScoreIncreaseModel>>()
        };
    }
}