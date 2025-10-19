namespace Core.Models.Items;

public class CurrencyModel : ItemModel
{
    public string Denomination { get; set; } // cp, sp, ep, gp, pp
    public int Amount { get; set; }
}