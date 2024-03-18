using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Hangi şehrin hava durumunu görmek istiyorsunuz?");
            var cityName = Console.ReadLine();

            var baseUrl = "http://api.openweathermap.org/data/2.5/weather";
            var countryCode = "TR";
            var apiKey = "4f619a550169e697b0d2bd5852ed330d";

            var requestUrl = $"{baseUrl}?q={cityName},{countryCode}&appid={apiKey}&units=metric";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"Hata: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }
    }
}