namespace Domain.Models.Miscellaneous;

public class ChoiceModel<T>
{
    public string Description { get; set; } // "Choose one language of your choice"
    public int NumberToChoose { get; set; }
    public List<T> Options { get; set; } = new();
}