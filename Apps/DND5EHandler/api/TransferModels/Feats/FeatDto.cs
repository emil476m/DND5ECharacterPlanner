

using api.TransferModels.DndEntities;
using Domain.Models.Miscellaneous;

namespace api.TransferModels.Feats;

public class FeatDto : DndEntityDto
{
    public string Effect { get; set; } = String.Empty;
    public List<Choice<string>>? EffectChoices { get; set; } = new();
    
    
    public List<AbilityScoreIncrease>? AbilityScoreIncreases { get; set; } = new();
    public List<Choice<AbilityScoreIncrease>>? AbilityScoreIncreaseChoices { get; set; } = new();
}