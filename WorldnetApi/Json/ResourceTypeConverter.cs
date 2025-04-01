namespace WorldnetApi;

public static class ResourceTypeConverter
{
    public static string AsString(this ResourceType type)
    {
        return type switch
        {
            ResourceType.Payment => "PAYMENT",
            ResourceType.Sale => "SALE",
            ResourceType.PreAuth => "PREAUTH",
            ResourceType.Completion => "COMPLETION",
            ResourceType.Refund => "REFUND",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
    
    public static ResourceType FromString(this string type)
    {
        return type switch
        {
            "PAYMENT" => ResourceType.Payment,
            "SALE" => ResourceType.Sale,
            "PREAUTH" => ResourceType.PreAuth,
            "COMPLETION" => ResourceType.Completion,
            "REFUND" => ResourceType.Refund,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}