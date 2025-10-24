using Core.Enums;
using Core.Models.Miscellaneous;

namespace Core.Models.Items;

public abstract class ItemModel : DndEntityModel
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }

    public ProficiencyModel? RequiredProficiency { get; set; }
}