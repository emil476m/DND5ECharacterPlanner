namespace infrastructure.Models.Items;

public class WeaponModel : ItemModel
{
    public string Damage { get; set; } // example 1d8 or 2d12+4
    public string DamageType { get; set; } // example Slashing, Piercing, Fire
    public bool IsFinesse { get; set; }
    public bool IsHeavy { get; set; }
    public bool IsTwoHanded { get; set; }
    public bool IsRanged { get; set; }
    public int RangeNormal { get; set; }
    public int? RangeMax { get; set; }
}