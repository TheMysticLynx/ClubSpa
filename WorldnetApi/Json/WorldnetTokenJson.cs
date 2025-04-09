#region

using Newtonsoft.Json;

#endregion

namespace WorldnetApi.Json;

public class WorldnetTokenJson
{
    [JsonProperty("allowedTerminals")] public List<string> AllowedTerminals = null!;
    [JsonProperty("audience")] public string Audience = null!;

    [JsonProperty("boundTo")] public string BoundTo = null!;

    [JsonProperty("enableHypermedia")] public bool EnableHypermedia;

    [JsonProperty("enableReceipts")] public bool EnableReceipts;

    [JsonProperty("expiresIn")] public int ExpiresIn;

    [JsonProperty("roles")] public List<string> Roles = null!;

    [JsonProperty("token")] public string Token = null!;

    [JsonProperty("tokenType")] public string TokenType = null!;
}