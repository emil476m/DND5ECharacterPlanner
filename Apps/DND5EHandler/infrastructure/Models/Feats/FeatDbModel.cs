using Domain.Models;
using Domain.Models.Miscellaneous;

namespace infrastructure.Models.Feats;

public class FeatDbModel : DndEntity
{
    public string Effect { get; set; }
    public List<Choice<string>>? EffectChoices { get; set; } = new();
    
    public List<AbilityScoreIncrease> AbilityScoreIncreases { get; set; } = new();
    public List<Choice<AbilityScoreIncrease>> AbilityScoreIncreaseChoices { get; set; } = new();
}