namespace Domain.Models.Miscellaneous;

public class UsageLimitModel
{
    public int? UsesPerLongRest { get; set; }
    public int? UsesPerShortRest { get; set; }
    public bool Unlimited { get; set; }
    public string RechargeCondition { get; set; } // "Recharge 5-6"
}