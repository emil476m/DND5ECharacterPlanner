using Core.Enums;
using Core.Models.Miscellaneous;

namespace infrastructure.DatabaseModels.Items;

public class ItemDbModel : DndEntityDbModel
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }
    
    public ProficiencyModel RequiredProficiency { get; set; }
}