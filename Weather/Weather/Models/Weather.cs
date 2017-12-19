namespace Weather.Models
{
    public class Weather
    {
        public string Temperature { get; set; }
        public string Time { get; set; }

        public Weather()
        {
            this.Temperature = "";
            this.Time = "";
        }
    }
}
