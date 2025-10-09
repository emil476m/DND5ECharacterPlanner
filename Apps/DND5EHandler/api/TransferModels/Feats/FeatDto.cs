

using api.TransferModels.DndEntities;
using Domain.Models.Miscellaneous;

namespace api.TransferModels.Feats;

public class FeatDto : DndEntityDto
{
    public string Effect { get; set; } = String.Empty;
    public List<ChoiceModel<string>>? EffectChoices { get; set; } = new();
    
    
    public List<AbilityScoreIncreaseModel>? AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>>? AbilityScoreIncreaseChoices { get; set; } = new();
}