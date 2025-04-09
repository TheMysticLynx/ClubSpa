#region

using static WorldnetApi.SearchTransactionsQuery.TenderTypeOption;

#endregion

namespace WorldnetApi.Json.Converters;

public static class TenderTypeOptionConverter
{
    public static string AsString(this SearchTransactionsQuery.TenderTypeOption typeOption)
    {
        return typeOption switch
        {
            CreditDebit => "CREDIT_DEBIT",
            Ebt => "EBT",
            _ => throw new ArgumentOutOfRangeException(nameof(typeOption), typeOption, null)
        };
    }

    public static SearchTransactionsQuery.TenderTypeOption FromString(this string type)
    {
        return type switch
        {
            "CREDIT_DEBIT" => CreditDebit,
            "EBT" => Ebt,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}