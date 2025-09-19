using infrastructure.Models.Miscellaneous;
using infrastructure.Models.Miscellaneous.Enums;

namespace infrastructure.Models.Items;

public abstract class ItemModel : DndEntity
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }
    
    public List<Proficiency> RequiredProficiencies { get; set; } = new();
}

