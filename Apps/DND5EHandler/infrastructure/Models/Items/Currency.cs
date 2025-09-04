namespace infrastructure.Models.Items;

public class Currency : Item
{
    public string Denomination { get; set; } // cp, sp, ep, gp, pp
    public int Amount { get; set; }
}