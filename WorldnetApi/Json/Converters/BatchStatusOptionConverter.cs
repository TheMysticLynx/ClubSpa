#region

using Newtonsoft.Json;
using static WorldnetApi.Json.SearchTransactionsResponseJson.DataJson.BatchStatusOption;

#endregion

namespace WorldnetApi.Json.Converters;

public class BatchStatusOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(SearchTransactionsResponseJson.DataJson.BatchStatusOption);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.Value is string value)
            return value switch
            {
                "SENT" => Sent,
                "COMPLETE" => Complete,
                "REJECTED" => Rejected,
                "REVERTED" => Reverted,
                "RESTORED" => Restored,
                "ADMIN" => Admin,
                "IN_PROGRESS" => InProgress,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };

        return Sent;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is SearchTransactionsResponseJson.DataJson.BatchStatusOption batchStatus)
            writer.WriteValue(batchStatus switch
            {
                Sent => "SENT",
                Complete => "COMPLETE",
                Rejected => "REJECTED",
                Reverted => "REVERTED",
                Restored => "RESTORED",
                Admin => "ADMIN",
                InProgress => "IN_PROGRESS",
                _ => throw new ArgumentOutOfRangeException(nameof(batchStatus), batchStatus, null)
            });
    }
}