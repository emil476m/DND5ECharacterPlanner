using Domain.Models.Miscellaneous;

namespace Domain.Models.Feats;

public class FeatModel : DndEntity
{
    
    public string Effect { get; set; } = String.Empty;
    public List<Choice<string>>? EffectChoices { get; set; } = new();
    
    
    public List<AbilityScoreIncrease>? AbilityScoreIncreases { get; set; } = new();
    public List<Choice<AbilityScoreIncrease>>? AbilityScoreIncreaseChoices { get; set; } = new();
}