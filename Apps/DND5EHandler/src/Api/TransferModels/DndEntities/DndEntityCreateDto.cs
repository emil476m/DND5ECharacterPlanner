using Core.Enums;

namespace Api.TransferModels.DndEntities;

public class DndEntityCreateDto
{
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public RuleSet UsedRuleset { get; set; }
}