namespace Api.TransferModels.Items;

public class CurrencyDto : ItemDto
{
    public string Denomination { get; set; } // cp, sp, ep, gp, pp
    public int Amount { get; set; }
}