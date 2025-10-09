namespace Core.Models.Spells;

public class SpellModel : DndEntityModel
{
    public int Level { get; set; }
    public string School { get; set; }
    public string CastingTime { get; set; }
    public string Range { get; set; }
    public bool Somatic { get; set; }
    public bool Verbal { get; set; }
    public string? Material { get; set; }
    public string Duration { get; set; }
    public string Description { get; set; }
    public List<string> Classes  { get; set; } = new();
}