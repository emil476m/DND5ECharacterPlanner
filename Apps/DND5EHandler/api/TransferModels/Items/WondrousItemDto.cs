using Domain.Enums;

namespace api.TransferModels.Items;

public class WondrousItemDto : ItemDto
{
    public Rarity Rarity { get; set; }
    public bool RequiresAttunement { get; set; }
}