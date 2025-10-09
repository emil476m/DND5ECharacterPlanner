using Domain.Enums;

namespace Domain.Models;

public class DndEntitySimpleModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public RuleSet UsedRuleset { get; set; } 
}