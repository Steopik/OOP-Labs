using StudentManager.Application.Interfaces;
using System.Text.Json;

namespace StudentManager.Infrastructure.Adapters;

public class QuoteApiAdapter : IQuoteService
{
    private readonly HttpClient _httpClient;

    public QuoteApiAdapter()
    {
        _httpClient = new HttpClient();
    }

    public string GetMotivationalQuote()
    {
        try
        {
            var response = _httpClient.GetAsync("https://zenquotes.io/api/random").Result;
            response.EnsureSuccessStatusCode();

            var json = response.Content.ReadAsStringAsync().Result;
            var doc = JsonDocument.Parse(json);

            var quote = doc.RootElement[0].GetProperty("q").GetString();
            return $"{quote}";
        }
        catch
        {
            return "Не удалось получить цитату.";
        }
    }
}
