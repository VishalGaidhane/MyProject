using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
using Xamarin.Forms;

namespace Weather.Views
{
    public partial class MainWeatherPage : ContentPage
    {
        public MainWeatherPage()
        {
            InitializeComponent();
            this.BindingContext = new WeatherModel(this);
        }
    }
}
