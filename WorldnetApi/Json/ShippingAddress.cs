using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class ShippingAddress
{
    [JsonProperty("name")] public string? Name { get; set; }

    [JsonProperty("line1")] public string? Line1 { get; set; }

    [JsonProperty("line2")] public string? Line2 { get; set; }

    [JsonProperty("postalCode")] public string? PostalCode { get; set; }

    [JsonProperty("city")] public string? City { get; set; }

    [JsonProperty("state")] public string? State { get; set; }

    [JsonProperty("country")] public string? Country { get; set; }
}