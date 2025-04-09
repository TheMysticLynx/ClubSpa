#region

using Newtonsoft.Json;
using Serilog;
using WorldnetApi.Json;

#endregion

namespace WorldnetApi;

public class WorldnetController(string baseUrl, string apiKey)
{
    private readonly ILogger _log = Log.ForContext<WorldnetController>();

    private HttpClient _client = new()
    {
        BaseAddress = new Uri(baseUrl)
    };

    private WorldnetToken? _token;

    public async Task<PostPaymentInstructionsResponse> PostPaymentInstructions(string serialNumber,
        PostPaymentInstructionsBodyJson bodyJson)
    {
        await RefreshTokenIfNeeded();

        var url = $"/merchant/api/v1/transaction/devices/{serialNumber}/paymentInstructions";
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Headers = { { "Authorization", $"Bearer {_token!.Token}" } },
            Content = new StringContent(bodyJson.Serialize())
        };

        var response = await _client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PostPaymentInstructionsResponse>(json)!;
        }
        else
        {
            var json = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<WorldnetErrorJson>(json);
            _log.Error("Failed to post payment instructions: {error}", error);
            throw new Exception("Failed to post payment instructions");
        }
    }

    public async Task RefreshToken()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/merchant/api/v1/account/authenticate")
        {
            Headers = { { "Authorization", $"Basic {apiKey}" } }
        };

        var response = await _client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<WorldnetTokenJson>(json)!;
            _token = new WorldnetToken(token);
        }
        else
        {
            var json = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<WorldnetErrorJson>(json);
            _log.Error("Failed to authenticate: {error}", error);
            throw new Exception("Failed to authenticate");
        }

        _log.Information("Token refreshed: {token}", _token.Token);
    }

    public async Task<SearchTransactionsResponseJson> SearchTransaction(SearchTransactionsQuery query)
    {
        await RefreshTokenIfNeeded();

        var url = $"/merchant/api/v1/transaction/transactions{query.GetQuery()}";
        var request = new HttpRequestMessage(HttpMethod.Get, url)
        {
            Headers = { { "Authorization", $"Bearer {_token!.Token}" } }
        };

        var response = await _client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return SearchTransactionsResponseJson.FromJson(json);
        }
        else
        {
            var json = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<WorldnetErrorJson>(json);
            _log.Error("Failed to search transactions: {error}", error);
            throw new Exception("Failed to search transactions");
        }
    }

    private async Task RefreshTokenIfNeeded()
    {
        if (_token == null || _token.ExpiresIn.TotalMinutes < 10) await RefreshToken();
    }
}