using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Weather.Models
{
    public class WeatherModel
    {
        private ContentPage contentPage;
        public ICommand WeatherCommand { get; set; }

        public WeatherModel(ContentPage contentPage)
        {
            this.contentPage = contentPage;
            WeatherCommand = new Command(GetWeatherReport);
        }
        private async void GetWeatherReport()
        {
            try
            {
                Models.Weather weather = await WeatherRestAPI.WeatherRest.GetWeatherReport();
                if (weather != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "The temperature in New York was " + weather.Temperature + " and " + weather.Time, "OK");
                }
            }
            catch (Exception ex)
            {

                var exerr = ex.Message;

            }

        }
    }
}
