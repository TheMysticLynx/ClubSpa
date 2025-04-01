namespace WorldnetApi;

public static class BatchTypeConverter
{
    public static string AsString(this BatchType type)
    {
        return type switch
        {
            BatchType.Open => "OPEN",
            BatchType.Closed => "CLOSED",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
    
    public static BatchType FromString(this string type)
    {
        return type switch
        {
            "OPEN" => BatchType.Open,
            "CLOSED" => BatchType.Closed,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}