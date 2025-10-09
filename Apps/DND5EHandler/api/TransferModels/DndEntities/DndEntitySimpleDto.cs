using Core.Enums;

namespace api.TransferModels.DndEntities;

public class DndEntitySimpleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public RuleSet UsedRuleset { get; set; } 
}