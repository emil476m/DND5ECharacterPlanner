using infrastructure.Models.Feats;
using infrastructure.Models.Items;
using infrastructure.Models.Miscellaneous;

namespace infrastructure.Models.Backgrounds;

public class Background : DndEntity
{
    public string Description { get; set; } = string.Empty;

    // 1. Fixed Proficiencies
    public List<Proficiency> FixedProficiencies { get; set; } = new();

    // 2. Choice-Based Proficiencies
    public List<Choice<Proficiency>> ProficiencyChoices { get; set; } = new();

    // 3. Fixed and Choice-Based Languages
    public List<string> FixedLanguages { get; set; } = new();
    public List<Choice<string>> LanguageChoices { get; set; } = new();

    // 4. Starting Equipment
    public List<Item> StartingEquipment { get; set; } = new();

    // 5. Background Feature
    public BackgroundFeature Feature { get; set; } = new();

    // 6. Feats
    public List<Feat> FixedFeats { get; set; } = new();
    public List<Choice<Feat>> FeatChoices { get; set; } = new();

    // 7. Ability Score Increases
    public List<AbilityScoreIncrease> AbilityScoreIncreases { get; set; } = new();
    public List<Choice<AbilityScoreIncrease>> AbilityScoreIncreaseChoices { get; set; } = new();
}

public class BackgroundFeature
{
    public string Name { get; set; }
    public string Effect { get; set; }
}