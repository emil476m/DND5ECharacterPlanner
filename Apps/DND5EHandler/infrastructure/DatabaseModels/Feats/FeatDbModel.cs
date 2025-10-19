using Core.Models.Miscellaneous;

namespace infrastructure.DatabaseModels.Feats;

public class FeatDbModel : DndEntityDbModel
{
    public string Effect { get; set; }
    public List<ChoiceModel<string>>? EffectChoices { get; set; } = new();

    public List<AbilityScoreIncreaseModel> AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>> AbilityScoreIncreaseChoices { get; set; } = new();
}