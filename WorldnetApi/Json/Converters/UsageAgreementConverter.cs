using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class UsageAgreementConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not UsageAgreement usageAgreement) return;
        writer.WriteValue(usageAgreement switch
        {
            UsageAgreement.Unscheduled => "UNSCHEDULED",
            UsageAgreement.Recurring => "RECURRING",
            UsageAgreement.Installment => "INSTALLMENT",
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
        return objectType == typeof(UsageAgreement);
    }
}