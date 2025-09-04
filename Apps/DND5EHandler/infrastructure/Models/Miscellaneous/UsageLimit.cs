namespace infrastructure.Models.Miscellaneous;

public class UsageLimit
{
    public int? UsesPerLongRest { get; set; }
    public int? UsesPerShortRest { get; set; }
    public bool Unlimited { get; set; }
    public string RechargeCondition { get; set; } // "Recharge 5-6"
}