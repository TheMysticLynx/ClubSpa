#region

using Newtonsoft.Json;
using WorldnetApi.Json.Converters;

#endregion

namespace WorldnetApi.Json;

public class PostPaymentInstructionsResponse
{
    public enum PaymentInstructionsStatusOptions
    {
        Canceled,
        Completed,
        Failure,
        InProgress
    }

    [JsonProperty("errorMessage")] public string? ErrorMessage { get; set; }

    [JsonProperty("links")] public List<Link>? Links { get; set; }

    [JsonProperty("paymentInstructionId")] public string PaymentInstructionId { get; set; } = null!;

    [JsonProperty("status")]
    [JsonConverter(typeof(PaymentInstructionsStatusOptionConverter))]
    public PaymentInstructionsStatusOptions Status { get; set; }

    public class Link
    {
        [JsonProperty("href")] public string? Href { get; set; }

        [JsonProperty("method")] public string? Method { get; set; }

        [JsonProperty("rel")] public string? Rel { get; set; }
    }
}