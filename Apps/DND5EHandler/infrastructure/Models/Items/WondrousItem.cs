using infrastructure.Models.Miscellaneous.Enums;

namespace infrastructure.Models.Items;

public class WondrousItem : Item
{
    public Rarity Rarity { get; set; }
    public bool RequiresAttunement { get; set; }
}