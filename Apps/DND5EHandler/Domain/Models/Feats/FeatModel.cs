using Domain.Models.Miscellaneous;

namespace Domain.Models.Feats;

public class FeatModel : DndEntityModel
{
    
    public string Effect { get; set; } = String.Empty;
    public List<ChoiceModel<string>>? EffectChoices { get; set; } = new();
    
    
    public List<AbilityScoreIncreaseModel>? AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>>? AbilityScoreIncreaseChoices { get; set; } = new();
}