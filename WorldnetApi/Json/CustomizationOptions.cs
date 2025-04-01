using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class CustomizationOptions
{
    [JsonProperty("ebtDetails")] public EbtDetails? EbtDetails { get; set; }

    [JsonProperty("entryMethod")] public EntryMethod? EntryMethod { get; set; }
}