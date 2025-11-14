namespace Core.Models.Miscellaneous;

public class ProficiencyModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ProficiencyType? Type { get; set; }
}