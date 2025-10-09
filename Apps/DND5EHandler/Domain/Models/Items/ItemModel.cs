using Domain.Enums;
using Domain.Models.Miscellaneous;

namespace Domain.Models.Items;

public abstract class ItemModel : DndEntityModel
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }
    
    public List<ProficiencyModel> RequiredProficiencies { get; set; } = new();
}

