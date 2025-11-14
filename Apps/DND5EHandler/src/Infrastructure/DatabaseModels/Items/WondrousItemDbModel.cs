using Core.Enums;

namespace Infrastructure.DatabaseModels.Items;

public class WondrousItemDbModel : ItemDbModel
{
    public Rarity Rarity { get; set; }
    public bool RequiresAttunement { get; set; }
}