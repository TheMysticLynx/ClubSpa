#region

using Newtonsoft.Json;
using static WorldnetApi.Json.PostPaymentInstructionsResponse.PaymentInstructionsStatusOptions;

#endregion

namespace WorldnetApi.Json.Converters;

public class PaymentInstructionsStatusOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(PostPaymentInstructionsResponse.PaymentInstructionsStatusOptions) ||
               objectType == typeof(PostPaymentInstructionsResponse.PaymentInstructionsStatusOptions?);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.Value is string value)
            return value switch
            {
                "CANCELED" => Canceled,
                "COMPLETED" => Completed,
                "FAILURE" => Failure,
                "IN_PROGRESS" => InProgress,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };

        return Canceled;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is PostPaymentInstructionsResponse.PaymentInstructionsStatusOptions status)
            writer.WriteValue(status switch
            {
                Canceled => "CANCELED",
                Completed => "COMPLETED",
                Failure => "FAILURE",
                InProgress => "IN_PROGRESS",
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
            });
    }
}