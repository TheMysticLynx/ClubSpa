using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class WorldnetErrorJson
{
    [JsonProperty("debugIdentifier")]
    public string DebugIdentifier;

    [JsonProperty("details")]
    public List<Detail> Details;
}