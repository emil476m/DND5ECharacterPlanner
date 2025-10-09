using Domain.Models.Miscellaneous;

namespace Domain.Models.Races;

public class RacialAbility
{
    public string Name { get; set; } // "Darkvision", "Fey Step"
    public string Description { get; set; } // rules text

    // --- Mechanics ---
    public UsageLimit? UsageLimit { get; set; }   // optional (some traits are unlimited)

    // Ability Score bonuses (e.g., +2 DEX, +1 WIS)
    public List<AbilityScoreIncrease> AbilityScoreIncreases { get; set; } = new();
    public List<Choice<AbilityScoreIncrease>> AbilityScoreIncreaseChoices { get; set; } = new();

    // Proficiencies granted (skills, weapons, armor, tools)
    public List<Proficiency> Proficiencies { get; set; } = new();

    // Conditions or resistances (e.g., "Resistance to Poison damage")
    public List<string> Resistances { get; set; } = new();

    // Spells granted (some racial traits give spells, e.g., Tiefling)
    public List<SpellGrant> SpellsGranted { get; set; } = new();

    // Optional choices (e.g., Half-Elf chooses 2 skills)
    public List<Choice<object>> Choices { get; set; } = new();
}