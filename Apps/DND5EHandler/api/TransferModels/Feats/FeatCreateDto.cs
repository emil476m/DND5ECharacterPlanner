using api.TransferModels.DndEntities;
using Core.Models.Miscellaneous;

namespace api.TransferModels.Feats;

public class FeatCreateDto : DndEntityCreateDto
{
    public string Effect { get; set; }
    public List<ChoiceModel<string>>? EffectChoices { get; set; } = new();

    public List<AbilityScoreIncreaseModel>? AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>>? AbilityScoreIncreaseChoices { get; set; } = new();
}