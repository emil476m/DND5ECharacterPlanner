namespace api.TransferModels.Items;

public class ArmorDto : ItemDto
{
    public int ArmorClass { get; set; }
    public int MaxDexBonus { get; set; }
    public bool RequiresProficiency { get; set; }
    public string? ProficiencyType { get; set; }
    public int StrengthRequirement { get; set; }
    public bool IsShield { get; set; }
    public bool StealthDisadvantage { get; set; }
}