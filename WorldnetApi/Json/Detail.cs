using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class Detail
{
    [JsonProperty("errorCode")]
    public string ErrorCode;

    [JsonProperty("errorMessage")]
    public string ErrorMessage;

    [JsonProperty("source")]
    public SourceJson Source;
}