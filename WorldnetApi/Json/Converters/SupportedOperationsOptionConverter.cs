#region

using Newtonsoft.Json;
using static WorldnetApi.Json.SearchTransactionsResponseJson.DataJson.SupportedOperationOption;

#endregion

namespace WorldnetApi.Json.Converters;

public class SupportedOperationsOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(SearchTransactionsResponseJson.DataJson.SupportedOperationOption);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.Value is string value)
            return value switch
            {
                "CAPTURE" => Capture,
                "REFUND" => Refund,
                "FULLY_REVERSE" => FullyReverse,
                "PARTIALLY_REVERSE" => PartiallyReverse,
                "INCREMENT_AUTHORIZATION" => IncrementAuthorization,
                "ADJUST_TIP" => AdjustTip,
                "ADD_SIGNATURE" => AddSignature,
                "SET_AS_READY" => SetAsReady,
                "SET_AS_PENDING" => SetAsPending,
                "SET_AS_DECLINED" => SetAsDeclined,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };

        return Capture;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is SearchTransactionsResponseJson.DataJson.SupportedOperationOption supportedOperations)
            writer.WriteValue(supportedOperations switch
            {
                Capture => "CAPTURE",
                Refund => "REFUND",
                FullyReverse => "FULLY_REVERSE",
                PartiallyReverse => "PARTIALLY_REVERSE",
                IncrementAuthorization =>
                    "INCREMENT_AUTHORIZATION",
                AdjustTip => "ADJUST_TIP",
                AddSignature => "ADD_SIGNATURE",
                SetAsReady => "SET_AS_READY",
                SetAsPending => "SET_AS_PENDING",
                SetAsDeclined => "SET_AS_DECLINED",
                _ => throw new ArgumentOutOfRangeException(nameof(supportedOperations), supportedOperations, null)
            });
    }
}