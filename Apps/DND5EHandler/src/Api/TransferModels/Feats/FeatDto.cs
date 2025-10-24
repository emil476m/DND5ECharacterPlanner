using Api.TransferModels.DndEntities;
using Core.Models.Miscellaneous;

namespace Api.TransferModels.Feats;

public class FeatDto : DndEntityDto
{
    public string Effect { get; set; } = string.Empty;
    public List<ChoiceModel<string>>? EffectChoices { get; set; } = new();


    public List<AbilityScoreIncreaseModel>? AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>>? AbilityScoreIncreaseChoices { get; set; } = new();
}