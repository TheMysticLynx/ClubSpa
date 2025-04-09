#region

using static WorldnetApi.SearchTransactionsQuery.TipModeOption;

#endregion

namespace WorldnetApi.Json.Converters;

public static class TipModeOptionConverter
{
    public static string AsString(this SearchTransactionsQuery.TipModeOption modeOption)
    {
        return modeOption switch
        {
            NoTip => "NO_TIP",
            Prompted => "PROMPTED",
            Adjusted => "ADJUSTED",
            _ => throw new ArgumentOutOfRangeException(nameof(modeOption), modeOption, null)
        };
    }

    public static SearchTransactionsQuery.TipModeOption FromString(this string mode)
    {
        return mode switch
        {
            "NO_TIP" => NoTip,
            "PROMPTED" => Prompted,
            "ADJUSTED" => Adjusted,
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
        };
    }
}