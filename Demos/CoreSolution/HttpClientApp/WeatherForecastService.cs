using Newtonsoft.Json;

namespace HttpClientApp;

public class WeatherForecastService
{
    private readonly HttpClient _httpClient;

    public WeatherForecastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IEnumerable<WeatherForecast>? GetWeather()
    {
        var response = _httpClient.GetAsync("WeatherForecast").Result;
        if (response.IsSuccessStatusCode)
        {
            var strData = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(strData);
        }
        return null;
    }
}
