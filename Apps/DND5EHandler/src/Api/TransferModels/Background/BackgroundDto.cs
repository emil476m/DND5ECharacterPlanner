using Api.TransferModels.DndEntities;
using Core.Models.Backgrounds;
using Core.Models.Feats;
using Core.Models.Items;
using Core.Models.Miscellaneous;

namespace Api.TransferModels.Background;

public class BackgroundDto : DndEntityDto
{
    public string Description { get; set; } = string.Empty;
    
    // Background Feature
    public BackgroundFeatureModel? FeatureModel { get; set; } = new();
    
    public CharacteristicsModel? Characteristics { get; set; } = new();

    // Proficiencies
    public List<ProficiencyModel>? FixedProficiencies { get; set; }
    public List<ChoiceModel<ProficiencyModel>>? ProficiencyChoices { get; set; }

    // Languages
    public List<LanguageModel>? FixedLanguages { get; set; }
    public ChoiceModel<LanguageModel>? LanguageChoices { get; set; }

    // Starting Equipment
    public List<ItemModel>? StartingEquipment { get; set; }
    public ChoiceModel<ItemModel>? StartingEquipmentChoices { get; set; }

    

    // Feats
    public FeatModel? FixedFeats { get; set; }
    public ChoiceModel<FeatModel>? FeatChoices { get; set; }

    // Ability Score Increases
    public List<ChoiceModel<AbilityScoreIncreaseModel>>? AbilityScoreIncreaseChoices { get; set; }
}