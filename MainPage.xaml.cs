using Maui_MZ.Model;
using Newtonsoft.Json;

namespace Maui_MZ;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnGetWeatherClicked(object sender, EventArgs e)
	{
		string latitud = lat.Text;
        string longitud = lon.Text;

		using (var client = new HttpClient())
		{
			var url = $"https://api.openweathermap.org/data/2.5/weather?lat= " + latitud + "&lon=" + longitud + "&appid=ebb27cc49bae97ea1c28d8591c96d9ff";
			var response = client.GetAsync(url).Result;
			if (response.IsSuccessStatusCode)
			{
				string content = response.Content.ReadAsStringAsync().Result;
				var weatherData = JsonConvert.DeserializeObject<Clima>(content);
				weatherLabel.Text = weatherData.weather[0].description;
				pais.Text = weatherData.sys.country;
				Ciudad.Text = weatherData.name;

            }
		}
    }

}

