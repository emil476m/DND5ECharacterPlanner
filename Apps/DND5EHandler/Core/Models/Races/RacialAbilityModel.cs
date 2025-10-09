using Core.Models.Miscellaneous;

namespace Core.Models.Races;

public class RacialAbilityModel
{
    public string Name { get; set; } // "Darkvision", "Fey Step"
    public string Description { get; set; } // rules text

    // --- Mechanics ---
    public UsageLimitModel? UsageLimit { get; set; }   // optional (some traits are unlimited)

    // Ability Score bonuses (e.g., +2 DEX, +1 WIS)
    public List<AbilityScoreIncreaseModel> AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>> AbilityScoreIncreaseChoices { get; set; } = new();

    // Proficiencies granted (skills, weapons, armor, tools)
    public List<ProficiencyModel> Proficiencies { get; set; } = new();

    // Conditions or resistances (e.g., "Resistance to Poison damage")
    public List<string> Resistances { get; set; } = new();

    // Spells granted (some racial traits give spells, e.g., Tiefling)
    public List<SpellGrantModel> SpellsGranted { get; set; } = new();

    // Optional choices (e.g., Half-Elf chooses 2 skills)
    public List<ChoiceModel<object>> Choices { get; set; } = new();
}