#region

using Newtonsoft.Json;

#endregion

namespace WorldnetApi.Json;

public class WorldnetErrorJson
{
    [JsonProperty("debugIdentifier")] public string DebugIdentifier;

    [JsonProperty("details")] public List<DetailJson> Details;

    public class DetailJson
    {
        [JsonProperty("errorCode")] public string ErrorCode;

        [JsonProperty("errorMessage")] public string ErrorMessage;

        [JsonProperty("source")] public SourceJson Source;

        public class SourceJson
        {
            [JsonProperty("location")] public string Location;

            [JsonProperty("property")] public string Property;
        }
    }
}