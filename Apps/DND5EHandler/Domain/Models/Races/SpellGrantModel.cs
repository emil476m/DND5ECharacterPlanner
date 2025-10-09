namespace Domain.Models.Races;

public class SpellGrantModel
{
    public string SpellName { get; set; }
    public int LevelAvailable { get; set; }   // when do they get it
    public string CastingAbility { get; set; } // "CHA", "INT"
    public string Frequency { get; set; }      // "Once per long rest", "Always prepared"
}