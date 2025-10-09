using api.TransferModels.DndEntities;
using infrastructure.Models.Miscellaneous;

namespace api.TransferModels.Feats;

public class FeatCreateDto : DndEntityCreateDto
{
    public string Effect { get; set; }
    public List<Choice<string>>? EffectChoices { get; set; } = new();
    
    public List<AbilityScoreIncrease>? AbilityScoreIncreases { get; set; } = new();
    public List<Choice<AbilityScoreIncrease>>? AbilityScoreIncreaseChoices { get; set; } = new();
}