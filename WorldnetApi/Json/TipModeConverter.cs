namespace WorldnetApi;

public static class TipModeConverter
{
    public static string AsString(this TipMode mode)
    {
        return mode switch
        {
            TipMode.NoTip => "NO_TIP",
            TipMode.Prompted => "PROMPTED",
            TipMode.Adjusted => "ADJUSTED",
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
        };
    }
    
    public static TipMode FromString(this string mode)
    {
        return mode switch
        {
            "NO_TIP" => TipMode.NoTip,
            "PROMPTED" => TipMode.Prompted,
            "ADJUSTED" => TipMode.Adjusted,
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
        };
    }
}