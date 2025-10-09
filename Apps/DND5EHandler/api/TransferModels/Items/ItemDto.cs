using api.TransferModels.DndEntities;
using Domain.Enums;
using Domain.Models.Miscellaneous;

namespace api.TransferModels.Items;

public class ItemDto : DndEntityDto
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }
    
    public List<ProficiencyModel> RequiredProficiencies { get; set; } = new();
}