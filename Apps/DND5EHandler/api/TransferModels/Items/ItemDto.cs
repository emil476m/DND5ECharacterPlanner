using System.Text.Json.Serialization;
using api.TransferModels.DndEntities;
using Core.Enums;
using Core.Models.Miscellaneous;

namespace api.TransferModels.Items;

//Doing explicit mappings for specific categories so i can use ItemDto to return all subtypes in a single endpoint
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(ArmorDto), (int)ItemCategory.ArmorAndShields)]
[JsonDerivedType(typeof(CurrencyDto), (int)ItemCategory.Currency)]
[JsonDerivedType(typeof(WeaponDto), (int)ItemCategory.Weapon)]
[JsonDerivedType(typeof(WondrousItemDto), (int)ItemCategory.WondrousItem)]
[JsonDerivedType(typeof(GenericItemDto), -1)] // -1 to catch all other categories not explicitly defined above
public class ItemDto : DndEntityDto
{
    public ItemCategory Category { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int? CostInGold { get; set; }

    public ProficiencyModel? RequiredProficiency { get; set; }
}