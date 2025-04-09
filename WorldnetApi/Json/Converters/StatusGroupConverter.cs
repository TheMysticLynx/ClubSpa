namespace WorldnetApi.Json.Converters;

public static class StatusGroupConverter
{
    public static string AsString(this SearchTransactionsQuery.StatusGroupOption groupOption)
    {
        return groupOption switch
        {
            SearchTransactionsQuery.StatusGroupOption.Approved => "APPROVED",
            SearchTransactionsQuery.StatusGroupOption.Declined => "DECLINED",
            SearchTransactionsQuery.StatusGroupOption.Reversal => "REVERSAL",
            SearchTransactionsQuery.StatusGroupOption.Referral => "REFERRAL",
            SearchTransactionsQuery.StatusGroupOption.Accepted => "ACCEPTED",
            _ => throw new ArgumentOutOfRangeException(nameof(groupOption), groupOption, null)
        };
    }

    public static SearchTransactionsQuery.StatusGroupOption FromString(this string group)
    {
        return group switch
        {
            "APPROVED" => SearchTransactionsQuery.StatusGroupOption.Approved,
            "DECLINED" => SearchTransactionsQuery.StatusGroupOption.Declined,
            "REVERSAL" => SearchTransactionsQuery.StatusGroupOption.Reversal,
            "REFERRAL" => SearchTransactionsQuery.StatusGroupOption.Referral,
            "ACCEPTED" => SearchTransactionsQuery.StatusGroupOption.Accepted,
            _ => throw new ArgumentOutOfRangeException(nameof(group), group, null)
        };
    }
}