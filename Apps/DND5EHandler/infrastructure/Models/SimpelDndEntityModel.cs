using infrastructure.Models.Miscellaneous.Enums;

namespace infrastructure.Models;

public class SimpelDndEntityModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public RuleSet UsedRuleset { get; set; } 
}