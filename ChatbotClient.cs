using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class ChatbotClient
{
    private readonly HttpClient _httpClient;
    private readonly string _endpointUrl;
    private readonly string _apiKey;

    public ChatbotClient(string endpointUrl, string apiKey)
    {
        _httpClient = new HttpClient();
        _endpointUrl = endpointUrl;
        _apiKey = apiKey;
    }

    public async Task<string> SendMessage(string message)
    {
        var requestContent = new StringContent(
            $"{{\"prompt\": \"{message}\"}}",
            Encoding.UTF8,
            "application/json");

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);

        var response = await _httpClient.PostAsync(_endpointUrl, requestContent);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
}
