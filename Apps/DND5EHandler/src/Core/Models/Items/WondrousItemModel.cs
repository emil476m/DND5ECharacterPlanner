using Core.Enums;

namespace Core.Models.Items;

public class WondrousItemModel : ItemModel
{
    public Rarity Rarity { get; set; }
    public bool RequiresAttunement { get; set; }
}