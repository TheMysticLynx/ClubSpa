namespace WorldnetApi;

public static class StatusGroupConverter
{
    public static string AsString(this StatusGroup group)
    {
        return group switch
        {
            StatusGroup.Approved => "APPROVED",
            StatusGroup.Declined => "DECLINED",
            StatusGroup.Reversal => "REVERSAL",
            StatusGroup.Referral => "REFERRAL",
            StatusGroup.Accepted => "ACCEPTED",
            _ => throw new ArgumentOutOfRangeException(nameof(group), group, null)
        };
    }
    
    public static StatusGroup FromString(this string group)
    {
        return group switch
        {
            "APPROVED" => StatusGroup.Approved,
            "DECLINED" => StatusGroup.Declined,
            "REVERSAL" => StatusGroup.Reversal,
            "REFERRAL" => StatusGroup.Referral,
            "ACCEPTED" => StatusGroup.Accepted,
            _ => throw new ArgumentOutOfRangeException(nameof(group), group, null)
        };
    }
}