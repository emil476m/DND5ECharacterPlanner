using infrastructure.Models.Miscellaneous.Enums;

namespace api.TransferModels.DndEntities;

public class DndEntityCreateDto
{
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public RuleSet UsedRuleset { get; set; } 
}