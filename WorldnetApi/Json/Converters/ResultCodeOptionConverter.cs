#region

using Newtonsoft.Json;
using static WorldnetApi.Json.SearchTransactionsResponseJson.DataJson;

#endregion

namespace WorldnetApi.Json.Converters;

public class ResultCodeOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(ResultCodeOption) ||
               objectType == typeof(ResultCodeOption?);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.Value is string value)
            return value switch
            {
                "A" => ResultCodeOption.Approved,
                "D" => ResultCodeOption.Declined,
                "E" => ResultCodeOption.AcceptedForLaterProcessing,
                "P" => ResultCodeOption.PartialApproval,
                "R" => ResultCodeOption.ContactCardIssuer,
                "C" => ResultCodeOption.RetainCard,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };

        return ResultCodeOption.Approved;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is ResultCodeOption resultCode)
            writer.WriteValue(resultCode switch
            {
                ResultCodeOption.Approved => "A",
                ResultCodeOption.Declined => "D",
                ResultCodeOption.AcceptedForLaterProcessing => "E",
                ResultCodeOption.PartialApproval => "P",
                ResultCodeOption.ContactCardIssuer => "R",
                ResultCodeOption.RetainCard => "C",
                _ => throw new ArgumentOutOfRangeException(nameof(resultCode), resultCode, null)
            });
    }
}