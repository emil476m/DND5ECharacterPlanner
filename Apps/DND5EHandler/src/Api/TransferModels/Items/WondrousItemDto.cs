using Core.Enums;

namespace Api.TransferModels.Items;

public class WondrousItemDto : ItemDto
{
    public Rarity Rarity { get; set; }
    public bool RequiresAttunement { get; set; }
}