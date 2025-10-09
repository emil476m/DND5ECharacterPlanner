using infrastructure.Models.Miscellaneous.Enums;

namespace api.TransferModels;

public class DndEntitySimpleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public RuleSet UsedRuleset { get; set; } 
}