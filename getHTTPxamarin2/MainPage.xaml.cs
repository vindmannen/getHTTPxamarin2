using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Microcharts;
using SkiaSharp;

namespace getHTTPxamarin2
{
    public partial class MainPage : ContentPage

    {
        public MainPage()
        {
            InitializeComponent();            
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var entries = new List<ChartEntry>();

            var httpClient = new HttpClient();
            var resultJSON = await httpClient.GetStringAsync("https://api.kolada.se/v1/data/permunicipality/N07403/0180");
            Values resultKolada = JsonConvert.DeserializeObject<Values>(resultJSON);
                                 
            foreach (var item in resultKolada.values)
            {
                Random ran = new Random();
                SKColor randomColor = SKColor.FromHsv(ran.Next(256), ran.Next(256), ran.Next(256));
                var entry = new ChartEntry(item.value)
                {
                    Label = item.value.ToString(),
                    Color = randomColor,
                    ValueLabel = item.period
                };
                entries.Add(entry);
             }
            chartViewBar.Chart = new BarChart
            {
                Entries = entries,
                ValueLabelOrientation = Orientation.Vertical,
                LabelTextSize = 30
            };
        }
    }
}
