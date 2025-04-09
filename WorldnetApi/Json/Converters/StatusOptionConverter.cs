#region

using Newtonsoft.Json;
using static WorldnetApi.Json.SearchTransactionsResponseJson.DataJson;

#endregion

namespace WorldnetApi.Json.Converters;

public class StatusOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(StatusOption);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.Value is string value)
            return value switch
            {
                "READY" => StatusOption.Ready,
                "PENDING" => StatusOption.Pending,
                "VOID" => StatusOption.Void,
                "DECLINED" => StatusOption.Declined,
                "COMPLETE" => StatusOption.Complete,
                "REFERRAL" => StatusOption.Referral,
                "PICKUP" => StatusOption.Pickup,
                "REVERSAL" => StatusOption.Reversal,
                "SENT" => StatusOption.Sent,
                "ADMIN" => StatusOption.Admin,
                "EXPIRED" => StatusOption.Expired,
                "ACCEPTED" => StatusOption.Accepted,
                "REVIEW" => StatusOption.Review,
                "OTHER" => StatusOption.Other,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };

        return StatusOption.Ready;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is StatusOption status)
            writer.WriteValue(status switch
            {
                StatusOption.Ready => "READY",
                StatusOption.Pending => "PENDING",
                StatusOption.Void => "VOID",
                StatusOption.Declined => "DECLINED",
                StatusOption.Complete => "COMPLETE",
                StatusOption.Referral => "REFERRAL",
                StatusOption.Pickup => "PICKUP",
                StatusOption.Reversal => "REVERSAL",
                StatusOption.Sent => "SENT",
                StatusOption.Admin => "ADMIN",
                StatusOption.Expired => "EXPIRED",
                StatusOption.Accepted => "ACCEPTED",
                StatusOption.Review => "REVIEW",
                StatusOption.Other => "OTHER",
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
            });
    }
}