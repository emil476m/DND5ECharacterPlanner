using api.TransferModels.DndEntities;
using Core.Enums;
using Core.Models.Miscellaneous;

namespace api.TransferModels.Items;

public class CreateItemDto : DndEntityCreateDto
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }
    
    public ProficiencyModel? RequiredProficiency { get; set; }
}