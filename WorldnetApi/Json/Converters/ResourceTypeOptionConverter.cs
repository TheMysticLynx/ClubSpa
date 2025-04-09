#region

using static WorldnetApi.SearchTransactionsQuery.ResourceTypeOption;

#endregion

namespace WorldnetApi.Json.Converters;

public static class ResourceTypeOptionConverter
{
    public static string AsString(this SearchTransactionsQuery.ResourceTypeOption typeOption)
    {
        return typeOption switch
        {
            Payment => "PAYMENT",
            Sale => "SALE",
            PreAuth => "PREAUTH",
            Completion => "COMPLETION",
            Refund => "REFUND",
            _ => throw new ArgumentOutOfRangeException(nameof(typeOption), typeOption, null)
        };
    }

    public static SearchTransactionsQuery.ResourceTypeOption FromString(this string type)
    {
        return type switch
        {
            "PAYMENT" => Payment,
            "SALE" => Sale,
            "PREAUTH" => PreAuth,
            "COMPLETION" => Completion,
            "REFUND" => Refund,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}