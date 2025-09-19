using infrastructure.Models.Miscellaneous.Enums;

namespace infrastructure.Models.Items;

public class WondrousItemModel : ItemModel
{
    public Rarity Rarity { get; set; }
    public bool RequiresAttunement { get; set; }
}