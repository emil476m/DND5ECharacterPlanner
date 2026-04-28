using Api.TransferModels.Background;
using Core.Enums;
using Core.Models.Backgrounds;

namespace Api.Mappers.Background;

public static class BackgroundMapper
{
    public static BackgroundDto ToBackgroundDto(this BackgroundModel model)
    {
        return new BackgroundDto
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
            Source = model.Source,

            //background model
            Description = model.Description,
            FeatureModel = model.FeatureModel,
            Characteristics = model.Characteristics,
            FixedProficiencies = model.FixedProficiencies,
            ProficiencyChoices = model.ProficiencyChoices,
            FixedLanguages = model.FixedLanguages,
            LanguageChoices = model.LanguageChoices,
            StartingEquipment = model.StartingEquipment,
            StartingEquipmentChoices = model.StartingEquipmentChoices,
            FixedFeats = model.FixedFeats,
            FeatChoices = model.FeatChoices,
            AbilityScoreIncreaseChoices = model.AbilityScoreIncreaseChoices
        };
    }
    
    
    public static BackgroundModel ToBackgroundModel(this BackgroundCreateDto dto)
    {
        return new BackgroundModel
        {
            //EntityModel
            Name = dto.Name,
            IsPublic = dto.IsPublic,
            UsedRuleset = dto.UsedRuleset,
            Type = EntityType.Background,
            Source = dto.Source,

            //BackgroundModel
            Description = dto.Description,
            FeatureModel = dto.FeatureModel,
            Characteristics = dto.Characteristics,
            FixedProficiencies = dto.FixedProficiencies,
            ProficiencyChoices = dto.ProficiencyChoices,
            FixedLanguages = dto.FixedLanguages,
            LanguageChoices = dto.LanguageChoices,
            StartingEquipment = dto.StartingEquipment,
            StartingEquipmentChoices = dto.StartingEquipmentChoices,
            FixedFeats = dto.FixedFeats,
            FeatChoices = dto.FeatChoices,
            AbilityScoreIncreaseChoices = dto.AbilityScoreIncreaseChoices
        };
    }
}