using Core.Enums;

namespace infrastructure.DatabaseModels.Items;

public class WondrousItemDbModel : ItemDbModel
{
    public Rarity Rarity { get; set; }
    public bool RequiresAttunement { get; set; }
}