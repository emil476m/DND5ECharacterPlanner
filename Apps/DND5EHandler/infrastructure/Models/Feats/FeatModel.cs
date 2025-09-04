using infrastructure.Models.Miscellaneous;

namespace infrastructure.Models.Feats;

public class FeatModel : DndEntity
{
    public string Effect { get; set; }
    public List<AbilityScoreIncrease>? AbilityScoreIncreases { get; set; } = new();
    public List<Choice<AbilityScoreIncrease>>? AbilityScoreIncreaseChoices { get; set; } = new();
}