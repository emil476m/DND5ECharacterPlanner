using System.Text.Json.Serialization;
using api.TransferModels.DndEntities;
using Core.Enums;
using Core.Models.Miscellaneous;

namespace api.TransferModels.Items;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(ArmorDto), (int)ItemCategory.ArmorAndShields)]
[JsonDerivedType(typeof(CurrencyDto), (int)ItemCategory.Currency)]
[JsonDerivedType(typeof(WeaponDto), (int)ItemCategory.Weapon)]
public class ItemDto : DndEntityDto
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }
    
    public List<ProficiencyModel> RequiredProficiencies { get; set; } = new();
}