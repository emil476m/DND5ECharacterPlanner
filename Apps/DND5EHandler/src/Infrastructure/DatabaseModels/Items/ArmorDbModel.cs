namespace Infrastructure.DatabaseModels.Items;

public class ArmorDbModel : ItemDbModel
{
    public int ArmorClass { get; set; }
    public int? MaxDexBonus { get; set; }
    public int StrengthRequirement { get; set; }
    public bool IsShield { get; set; }
    public bool StealthDisadvantage { get; set; }
}