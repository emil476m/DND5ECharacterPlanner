using Domain.Models.Feats;
using Domain.Models.Items;
using Domain.Models.Miscellaneous;

namespace Domain.Models.Backgrounds;

public class Background : DndEntity
{
    public string Description { get; set; } = string.Empty;

    // Fixed Proficiencies
    public List<Proficiency> FixedProficiencies { get; set; } = new();

    // Choice-Based Proficiencies
    public List<Choice<Proficiency>> ProficiencyChoices { get; set; } = new();

    // Fixed and Choice-Based Languages
    public List<string> FixedLanguages { get; set; } = new();
    public List<Choice<string>> LanguageChoices { get; set; } = new();

    // Starting Equipment
    public List<ItemModel> StartingEquipment { get; set; } = new();

    // Background Feature
    public BackgroundFeature Feature { get; set; } = new();

    // Feats
    public List<FeatModel> FixedFeats { get; set; } = new();
    public List<Choice<FeatModel>> FeatChoices { get; set; } = new();

    // Ability Score Increases
    public List<AbilityScoreIncrease> AbilityScoreIncreases { get; set; } = new();
    public List<Choice<AbilityScoreIncrease>> AbilityScoreIncreaseChoices { get; set; } = new();
}

