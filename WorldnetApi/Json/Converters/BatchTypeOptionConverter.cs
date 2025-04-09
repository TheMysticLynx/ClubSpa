#region

using static WorldnetApi.SearchTransactionsQuery.BatchTypeOption;

#endregion

namespace WorldnetApi.Json.Converters;

public static class BatchTypeOptionConverter
{
    public static string AsString(this SearchTransactionsQuery.BatchTypeOption typeOption)
    {
        return typeOption switch
        {
            Open => "OPEN",
            Closed => "CLOSED",
            _ => throw new ArgumentOutOfRangeException(nameof(typeOption), typeOption, null)
        };
    }

    public static SearchTransactionsQuery.BatchTypeOption FromString(this string type)
    {
        return type switch
        {
            "OPEN" => Open,
            "CLOSED" => Closed,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}