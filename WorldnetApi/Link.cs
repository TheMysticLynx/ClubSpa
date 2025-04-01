using Newtonsoft.Json;

namespace WorldnetApi;

public class Link
{
    [JsonProperty("rel")]
    public string? Rel { get; set; }
    
    [JsonProperty("href")]
    public string? Href { get; set; }
    
    [JsonProperty("method")]
    public string? Method { get; set; }
}