using infrastructure.Models.Miscellaneous;

namespace infrastructure.Models.Items;

public abstract class Item : DndEntity
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }
    
    public List<Proficiency> RequiredProficiencies { get; set; } = new();
}

public enum ItemCategory
{
    AdventuringGear,
    ArmorAndShields,
    Trinket,
    Weapon,
    Firearm,
    Explosive,
    WondrousItem,
    Currency,
    Poison,
    Tool,
    SiegeEquipment
}