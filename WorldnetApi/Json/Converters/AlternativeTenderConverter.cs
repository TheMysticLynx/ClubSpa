using Newtonsoft.Json;
using static WorldnetApi.Json.PostPaymentInstructionsBody.OrderJson.OrderBreakdownJson.DualPricingJson;

namespace WorldnetApi.Json.Converters;

public class AlternativeTenderConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not AlternativeTenderJson alternativeTender) return;
        writer.WriteValue(alternativeTender switch
        {
            AlternativeTenderJson.Card => "CARD",
            AlternativeTenderJson.Cash => "CASH",
            AlternativeTenderJson.BankTransfer => "BANK_TRANSFER",
            _ => throw new ArgumentOutOfRangeException()
        });
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return null;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(AlternativeTenderJson);
    }
}