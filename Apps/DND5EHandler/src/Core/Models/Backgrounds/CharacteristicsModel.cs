namespace Core.Models.Backgrounds;

public class CharacteristicsModel
{
    public string SuggestedCharacteristics { get; set; } = string.Empty;
    
    public List<string>? Ideal { get; set; }
    public List<string>? Bond { get; set; }
    public List<string>? Flaw { get; set; }
    public List<string>? PersonalityTrait { get; set; }
}