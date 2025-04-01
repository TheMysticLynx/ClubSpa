using Newtonsoft.Json;
using static WorldnetApi.Json.PostPaymentInstructionsBody.OrderJson.OrderBreakdownJson.TipOptionsJson.TipTypeJson;

namespace WorldnetApi.Json;

public class TipOptionsConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not PostPaymentInstructionsBody.OrderJson.OrderBreakdownJson.TipOptionsJson tipOptions) return;
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

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return null;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(PostPaymentInstructionsBody.OrderJson.OrderBreakdownJson.TipOptionsJson);
    }
}