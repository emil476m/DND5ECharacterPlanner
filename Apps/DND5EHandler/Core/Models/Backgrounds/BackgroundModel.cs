using Core.Models.Feats;
using Core.Models.Items;
using Core.Models.Miscellaneous;

namespace Core.Models.Backgrounds;

public class BackgroundModel : DndEntityModel
{
    public string Description { get; set; } = string.Empty;

    // Fixed Proficiencies
    public List<ProficiencyModel> FixedProficiencies { get; set; } = new();

    // Choice-Based Proficiencies
    public List<ChoiceModel<ProficiencyModel>> ProficiencyChoices { get; set; } = new();

    // Fixed and Choice-Based Languages
    public List<string> FixedLanguages { get; set; } = new();
    public List<ChoiceModel<string>> LanguageChoices { get; set; } = new();

    // Starting Equipment
    public List<ItemModel> StartingEquipment { get; set; } = new();

    // Background Feature
    public BackgroundFeatureModel FeatureModel { get; set; } = new();

    // Feats
    public List<FeatModel> FixedFeats { get; set; } = new();
    public List<ChoiceModel<FeatModel>> FeatChoices { get; set; } = new();

    // Ability Score Increases
    public List<AbilityScoreIncreaseModel> AbilityScoreIncreases { get; set; } = new();
    public List<ChoiceModel<AbilityScoreIncreaseModel>> AbilityScoreIncreaseChoices { get; set; } = new();
}

