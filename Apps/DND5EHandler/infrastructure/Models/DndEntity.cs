namespace infrastructure.Models;

public abstract class DndEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public bool IsOfficial { get; set; }
    public Guid? CreatedByUserId { get; set; }
    public DateTime CreatedOAt { get; set; }
    public RuleSet UsedRuleset { get; set; } 
    
}

public enum RuleSet
{
    DND5E_2014,
    DND5E_2024,
    Homebrew
}