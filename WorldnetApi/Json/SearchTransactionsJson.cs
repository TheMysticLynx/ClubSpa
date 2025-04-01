// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class SearchTransactionsJson
{
    [JsonProperty("data")] public List<DataJson> Data;

    public static SearchTransactionsJson FromJson(string json) => JsonConvert.DeserializeObject<SearchTransactionsJson>(
        json, new JsonConverter[]
        {
            new EbtTypeConverter(),
            new ResultCodeConverter()
        })!;
}