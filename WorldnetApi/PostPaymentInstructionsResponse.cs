using Newtonsoft.Json;

namespace WorldnetApi;

public class PostPaymentInstructionsResponse
{
    [JsonProperty("paymentInstructionId")] 
    public string PaymentInstructionId { get; set; } = null!;

    [JsonProperty("status")]
    [JsonConverter(typeof(StatusConverter))]
    public Status Status { get; set; }
    
    [JsonProperty("errorMessage")]
    public string? ErrorMessage { get; set; }
    
    [JsonProperty("links")]
    public List<Link>? Links { get; set; }
}