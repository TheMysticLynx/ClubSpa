using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class SupportedOperationsConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is SupportedOperations supportedOperations)
        {
            writer.WriteValue(supportedOperations switch
            {
                SupportedOperations.Capture => "CAPTURE",
                SupportedOperations.Refund => "REFUND",
                SupportedOperations.FullyReverse => "FULLY_REVERSE",
                SupportedOperations.PartiallyReverse => "PARTIALLY_REVERSE",
                SupportedOperations.IncrementAuthorization => "INCREMENT_AUTHORIZATION",
                SupportedOperations.AdjustTip => "ADJUST_TIP",
                SupportedOperations.AddSignature => "ADD_SIGNATURE",
                SupportedOperations.SetAsReady => "SET_AS_READY",
                SupportedOperations.SetAsPending => "SET_AS_PENDING",
                SupportedOperations.SetAsDeclined => "SET_AS_DECLINED",
                _ => throw new ArgumentOutOfRangeException(nameof(supportedOperations), supportedOperations, null)
            });
        }
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.Value is string value)
        {
            return value switch
            {
                "CAPTURE" => SupportedOperations.Capture,
                "REFUND" => SupportedOperations.Refund,
                "FULLY_REVERSE" => SupportedOperations.FullyReverse,
                "PARTIALLY_REVERSE" => SupportedOperations.PartiallyReverse,
                "INCREMENT_AUTHORIZATION" => SupportedOperations.IncrementAuthorization,
                "ADJUST_TIP" => SupportedOperations.AdjustTip,
                "ADD_SIGNATURE" => SupportedOperations.AddSignature,
                "SET_AS_READY" => SupportedOperations.SetAsReady,
                "SET_AS_PENDING" => SupportedOperations.SetAsPending,
                "SET_AS_DECLINED" => SupportedOperations.SetAsDeclined,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return SupportedOperations.Capture;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(SupportedOperations);
    }
}