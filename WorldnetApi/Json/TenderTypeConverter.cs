namespace WorldnetApi;

public static class TenderTypeConverter
{
    public static string AsString(this TenderType type)
    {
        return type switch
        {
            TenderType.CreditDebit => "CREDIT_DEBIT",
            TenderType.Ebt => "EBT",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    public static TenderType FromString(this string type)
    {
        return type switch
        {
            "CREDIT_DEBIT" => TenderType.CreditDebit,
            "EBT" => TenderType.Ebt,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}