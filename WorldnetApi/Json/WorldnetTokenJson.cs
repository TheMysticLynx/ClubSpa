using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class WorldnetTokenJson
{
    [JsonProperty("audience")] public string Audience = null!;

    [JsonProperty("boundTo")] public string BoundTo = null!;

    [JsonProperty("tokenType")] public string TokenType = null!;

    [JsonProperty("token")] public string Token = null!;

    [JsonProperty("expiresIn")] public int ExpiresIn;

    [JsonProperty("enableReceipts")] public bool EnableReceipts;

    [JsonProperty("enableHypermedia")] public bool EnableHypermedia;

    [JsonProperty("roles")] public List<string> Roles = null!;

    [JsonProperty("allowedTerminals")] public List<string> AllowedTerminals = null!;
}