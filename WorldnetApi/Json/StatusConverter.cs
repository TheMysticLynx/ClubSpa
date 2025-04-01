using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class StatusConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is Status status)
        {
            writer.WriteValue(status switch
            {
                Status.Ready => "READY",
                Status.Pending => "PENDING",
                Status.Void => "VOID",
                Status.Declined => "DECLINED",
                Status.Complete => "COMPLETE",
                Status.Referral => "REFERRAL",
                Status.Pickup => "PICKUP",
                Status.Reversal => "REVERSAL",
                Status.Sent => "SENT",
                Status.Admin => "ADMIN",
                Status.Expired => "EXPIRED",
                Status.Accepted => "ACCEPTED",
                Status.Review => "REVIEW",
                Status.Other => "OTHER",
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
                "READY" => Status.Ready,
                "PENDING" => Status.Pending,
                "VOID" => Status.Void,
                "DECLINED" => Status.Declined,
                "COMPLETE" => Status.Complete,
                "REFERRAL" => Status.Referral,
                "PICKUP" => Status.Pickup,
                "REVERSAL" => Status.Reversal,
                "SENT" => Status.Sent,
                "ADMIN" => Status.Admin,
                "EXPIRED" => Status.Expired,
                "ACCEPTED" => Status.Accepted,
                "REVIEW" => Status.Review,
                "OTHER" => Status.Other,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return Status.Ready;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Status);
    }
}