using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class BatchStatusConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is BatchStatus batchStatus)
        {
            writer.WriteValue(batchStatus switch
            {
                BatchStatus.Sent => "SENT",
                BatchStatus.Complete => "COMPLETE",
                BatchStatus.Rejected => "REJECTED",
                BatchStatus.Reverted => "REVERTED",
                BatchStatus.Restored => "RESTORED",
                BatchStatus.Admin => "ADMIN",
                BatchStatus.InProgress => "IN_PROGRESS",
                _ => throw new ArgumentOutOfRangeException(nameof(batchStatus), batchStatus, null)
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
                "SENT" => BatchStatus.Sent,
                "COMPLETE" => BatchStatus.Complete,
                "REJECTED" => BatchStatus.Rejected,
                "REVERTED" => BatchStatus.Reverted,
                "RESTORED" => BatchStatus.Restored,
                "ADMIN" => BatchStatus.Admin,
                "IN_PROGRESS" => BatchStatus.InProgress,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return BatchStatus.Sent;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(BatchStatus);
    }
}