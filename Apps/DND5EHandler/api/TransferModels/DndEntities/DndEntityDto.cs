using Domain.Enums;

namespace api.TransferModels.DndEntities;

public class DndEntityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public bool IsOfficial { get; set; }
    public Guid? CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public RuleSet UsedRuleset { get; set; } 
    public EntityType Type { get; set; }
}