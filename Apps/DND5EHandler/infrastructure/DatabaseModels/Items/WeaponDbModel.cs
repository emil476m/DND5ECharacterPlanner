namespace infrastructure.DatabaseModels.Items;

public class WeaponDbModel : ItemDbModel
{
    public string Damage { get; set; } // example 1d8 or 2d12+4
    public string DamageType { get; set; } // example Slashing, Piercing, Fire
    public string WeaponType { get; set; } // example Simple Melee, Martial Ranged
    public string Properties { get; set; } // example Finesse, Light, Heavy
    public int Range { get; set; }
}
