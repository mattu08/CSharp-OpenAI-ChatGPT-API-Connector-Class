# C# API Connector class created by OpenAI's ChatGPT itself
:computer: This C# code was created by a conversation with OpenAI's ChatGPT, ChatGPT created code to connect to the ChatGPT API.

I have logged the below chat with ChatGPT and code below, the code from the last question could be quite handy!

## First Question Asked: Can you create a C# class that can connect up to ChatGPT?

As an AI language model, I don't have an API or endpoint for direct connection. However, I can provide a sample C# class that demonstrates how to make an HTTP request to an API endpoint that can connect to a chatbot service.

Here is a sample C# class that uses the HttpClient class from the System.Net.Http namespace to send a POST request to a hypothetical API endpoint that takes a user's input and returns a response from a chatbot service:

To use this class, you'll need to obtain an API key from the OpenAI platform.

```cs
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ChatbotClient
{
    private readonly HttpClient _httpClient;
    private readonly string _endpointUrl;

    public ChatbotClient(string endpointUrl)
    {
        _httpClient = new HttpClient();
        _endpointUrl = endpointUrl;
    }

    public async Task<string> SendMessage(string message)
    {
        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("message", message)
        });

        var response = await _httpClient.PostAsync(_endpointUrl, requestContent);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
}
```

You can create an instance of this class by passing the URL of the API endpoint as a parameter to the constructor, like so:

```cs
var chatbotClient = new ChatbotClient("https://api.example.com/chatbot");
```

You can then use the SendMessage method to send a message to the chatbot and receive a response:

```cs
var response = await chatbotClient.SendMessage("Hello, ChatGPT!");
Console.WriteLine(response);
```

Note that this is just a sample implementation, and the actual implementation may vary depending on the specific chatbot service and API endpoint that you are working with.

## Last Question Asked: Can you add code for an open AI API key for the above code?

Sure! To use the OpenAI API, you would need to obtain an API key from the OpenAI platform. Once you have your API key, you can modify the **'ChatbotClient'** class to include the authentication header in the HTTP request. Here's an updated version of the **'ChatbotClient'** class that includes the OpenAI API key:

```cs
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
```

To use this class, create an instance of **'ChatbotClient'** by passing the URL of the OpenAI API endpoint and your API key:

```cs
var chatbotClient = new ChatbotClient(
    "https://api.openai.com/v1/engines/davinci-codex/completions",
    "YOUR_API_KEY_HERE");
```

Then, you can use the **'SendMessage'** method to send a message to the OpenAI chatbot:

```cs
var response = await chatbotClient.SendMessage("Hello, ChatGPT!");
Console.WriteLine(response);
```

Note that the **'ChatbotClient'** class in this example is specific to the OpenAI Codex API. If you are using a different OpenAI API or a different chatbot service, you will need to modify the code accordingly.

I hope this helps! Let me know if you have any questions.

Me: Thank You!

ChatGPT: You're welcome! If you have any more questions or if there's anything else I can help you with, feel free to ask.

**End Of Chat.** 
