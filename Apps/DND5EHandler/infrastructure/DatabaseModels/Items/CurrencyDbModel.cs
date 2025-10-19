namespace infrastructure.DatabaseModels.Items;

public class CurrencyDbModel : ItemDbModel
{
    public string Denomination { get; set; } // cp, sp, ep, gp, pp
    public int Amount { get; set; }
}