using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather.WeatherRestAPI
{
    public class WeatherRest
    {
        private const string apikey = "012b726fdec19be1";
        private const string apiurl = "http://api.wunderground.com/api/" + apikey + "/geolookup/conditions/q/IA/New York.json";

        public static async Task<Models.Weather> GetWeatherReport()
        {
            Models.Weather weather = new Models.Weather();
            var results = await Services.WeatherService.getWeatherDataFromService(apiurl).ConfigureAwait(false);
            JObject json = JObject.Parse(results);

            foreach (KeyValuePair<string, JToken> keyValuePair in json)
            {
                if (keyValuePair.Key == "current_observation")
                {
                    var item = keyValuePair.Value.ToString();

                    JObject json2 = JObject.Parse(item);
                    foreach (KeyValuePair<string, JToken> keyitem in json2)
                    {
                        if (keyitem.Key == "observation_time")
                        {
                            weather.Time = keyitem.Value.ToString();
                        }
                        if (keyitem.Key == "temperature_string")
                        {
                            weather.Temperature = keyitem.Value.ToString();
                        }
                    }
                }
            }

            return weather;
        }
    }
}
