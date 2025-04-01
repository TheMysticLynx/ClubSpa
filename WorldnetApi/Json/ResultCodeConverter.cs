using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class ResultCodeConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is ResultCode resultCode)
        {
            writer.WriteValue(resultCode switch
            {
                ResultCode.Approved => "A",
                ResultCode.Declined => "D",
                ResultCode.AcceptedForLaterProcessing => "E",
                ResultCode.PartialApproval => "P",
                ResultCode.ContactCardIssuer => "R",
                ResultCode.RetainCard => "C",
                _ => throw new ArgumentOutOfRangeException(nameof(resultCode), resultCode, null)
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
                "A" => ResultCode.Approved,
                "D" => ResultCode.Declined,
                "E" => ResultCode.AcceptedForLaterProcessing,
                "P" => ResultCode.PartialApproval,
                "R" => ResultCode.ContactCardIssuer,
                "C" => ResultCode.RetainCard,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return ResultCode.Approved;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(ResultCode) || objectType == typeof(ResultCode?);
    }
}