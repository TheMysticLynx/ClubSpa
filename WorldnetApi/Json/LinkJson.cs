using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class LinkJson
{
    [JsonProperty("rel")] public string? Rel;

    [JsonProperty("method")] public string? Method;

    [JsonProperty("href")] public string? Href;
}