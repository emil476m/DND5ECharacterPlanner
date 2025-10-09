using Domain.Models;
using Domain.Models.Miscellaneous;

namespace infrastructure.Models.Feats;

public class FeatDbModel : DndEntityModel
{
    public string Effect { get; set; }
    public List<ChoiceModel<string>>? EffectChoices { get; set; } = new();
    
    public List<AbilityScoreIncreaseModel> AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>> AbilityScoreIncreaseChoices { get; set; } = new();
}