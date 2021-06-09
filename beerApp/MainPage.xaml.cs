using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace beerApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void goToPedia(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://apirvbeers.azurewebsites.net/api/beers");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<BeerModel>>(content);
                beerList.ItemsSource = resultado;
            }

            }

        private void beerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }


    public class BeerModel
    {
        [JsonProperty ("$id")]
        public string Id { get; set; }
        public int id { get; set; }
        public string beer_name { get; set; }
        public string url_site { get; set; }
        public string url_img { get; set; }
        public float alcohol_grade { get; set; }
        public string country { get; set; }

    }
}
