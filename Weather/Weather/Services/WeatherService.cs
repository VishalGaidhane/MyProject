using System.Net.Http;
using System.Threading.Tasks;

namespace Weather.Services
{
    public class WeatherService
    {
        public static async Task<dynamic> getWeatherDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);
            string json = "";
            if (response != null)
            {
                json = response.Content.ReadAsStringAsync().Result;
            }

            return json;
        }
    }
}
