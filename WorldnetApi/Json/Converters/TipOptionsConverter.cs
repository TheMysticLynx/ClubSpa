#region

using Newtonsoft.Json;
using static WorldnetApi.Json.PostPaymentInstructionsBodyJson.OrderJson.OrderBreakdownJson;
using static WorldnetApi.Json.PostPaymentInstructionsBodyJson.OrderJson.OrderBreakdownJson.TipOptionsJson.TipTypeJson;

#endregion

namespace WorldnetApi.Json.Converters;

public class TipOptionsConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(TipOptionsJson);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not TipOptionsJson tipOptions) return;
        writer.WriteStartObject();
        writer.WritePropertyName("type");
        writer.WriteValue(tipOptions.TypeJson switch
        {
            Percentage => "PERCENTAGE",
            FixedAmount => "FIXED_AMOUNT",
            _ => throw new ArgumentOutOfRangeException()
        });
        writer.WritePropertyName(tipOptions.TypeJson switch
        {
            Percentage => "percentage",
            FixedAmount => "amount",
            _ => throw new ArgumentOutOfRangeException()
        });
        writer.WriteValue(tipOptions.Amount);
        writer.WriteEndObject();
    }
}