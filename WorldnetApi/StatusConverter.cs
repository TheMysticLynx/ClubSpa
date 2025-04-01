using Newtonsoft.Json;

namespace WorldnetApi;

public class StatusConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is Status status)
        {
            writer.WriteValue(status switch
            {
                Status.Canceled => "CANCELED",
                Status.Completed => "COMPLETED",
                Status.Failure => "FAILURE",
                Status.InProgress => "IN_PROGRESS",
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
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
                "CANCELED" => Status.Canceled,
                "COMPLETED" => Status.Completed,
                "FAILURE" => Status.Failure,
                "IN_PROGRESS" => Status.InProgress,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return Status.Canceled;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Status) || objectType == typeof(Status?);
    }
}