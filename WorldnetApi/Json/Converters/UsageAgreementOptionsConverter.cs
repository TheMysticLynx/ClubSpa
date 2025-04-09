#region

using Newtonsoft.Json;
using static WorldnetApi.Json.PostPaymentInstructionsBodyJson.OrderJson.CredentialOnFileJson.UsageAgreementOption;

#endregion

namespace WorldnetApi.Json.Converters;

public class UsageAgreementOptionsConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType ==
               typeof(PostPaymentInstructionsBodyJson.OrderJson.CredentialOnFileJson.UsageAgreementOption);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not PostPaymentInstructionsBodyJson.OrderJson.CredentialOnFileJson.UsageAgreementOption
            usageAgreement) return;
        writer.WriteValue(usageAgreement switch
        {
            Unscheduled =>
                "UNSCHEDULED",
            Recurring =>
                "RECURRING",
            Installment =>
                "INSTALLMENT",
            _ => throw new ArgumentOutOfRangeException()
        });
    }
}