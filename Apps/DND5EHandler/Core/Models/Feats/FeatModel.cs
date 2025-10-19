using Core.Models.Miscellaneous;

namespace Core.Models.Feats;

public class FeatModel : DndEntityModel
{
    public string Effect { get; set; } = string.Empty;
    public List<ChoiceModel<string>>? EffectChoices { get; set; } = new();


    public List<AbilityScoreIncreaseModel>? AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>>? AbilityScoreIncreaseChoices { get; set; } = new();
}