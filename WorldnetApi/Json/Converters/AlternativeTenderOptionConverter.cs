#region

using Newtonsoft.Json;
using static WorldnetApi.Json.PostPaymentInstructionsBodyJson.OrderJson.OrderBreakdownJson.DualPricingJson;

#endregion

namespace WorldnetApi.Json.Converters;

public class AlternativeTenderOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(AlternativeTenderOption);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not AlternativeTenderOption alternativeTender) return;
        writer.WriteValue(alternativeTender switch
        {
            AlternativeTenderOption.Card => "CARD",
            AlternativeTenderOption.Cash => "CASH",
            AlternativeTenderOption.BankTransfer => "BANK_TRANSFER",
            _ => throw new ArgumentOutOfRangeException()
        });
    }
}