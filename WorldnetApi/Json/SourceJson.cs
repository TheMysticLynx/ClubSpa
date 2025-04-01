using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class SourceJson
{
    [JsonProperty("location")]
    public string Location;

    [JsonProperty("property")]
    public string Property;
}