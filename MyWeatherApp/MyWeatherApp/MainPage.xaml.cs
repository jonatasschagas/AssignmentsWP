using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MyWeatherApp.Model;
using Newtonsoft.Json.Linq;
using MyWeatherApp.Util;
using Microsoft.Phone.Shell;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace MyWeatherApp
{
    public partial class MainPage : PhoneApplicationPage
    {

        private City city;
        PhoneApplicationService service = PhoneApplicationService.Current;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the city from the state object
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            city = ApplicationStateHelper.LoadCityFromAppState();

            if (city != null)
            {
                cityTextBox.Text = city.Name;
            }
            else
            {
                city = new City();
            }
        }

        /// <summary>
        /// Saves the city to the App State
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            try
            {
                if (!service.State.ContainsKey(City.KEY))
                {
                    ApplicationStateHelper.SaveCityToAppState(city);
                }
            }
            catch (System.ArgumentNullException)
            { }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            String search = cityTextBox.Text;
            searchCity(search);
        }

        /// <summary>
        /// Searches the city using Yahoo service based on user's input.
        /// </summary>
        /// <param name="cityName"></param>
        private void searchCity(String cityName)
        {
            try
            {
                cityName = cityName.Replace(" ", "");
                string url = @"http://query.yahooapis.com/v1/public/yql?q=" + Uri.EscapeDataString("select woeid,name from geo.places where text=\"" + cityName + "\" and placetype=\"Town\" limit 1 ;") + "&format=json&callback=";            
                WebClient client = new WebClient();
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(searchCityCallBack);
                client.DownloadStringAsync(new Uri(url, UriKind.Absolute));
                progressBar.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utils.GetMessage("CityNotFoundMessage"));
                return;
            }
        }

        private void searchCityCallBack(object sender, DownloadStringCompletedEventArgs e)
        {
            progressBar.Visibility = Visibility.Collapsed;
            if ((e.Result != null) && (e.Error == null))
            {
                try
                {

                    string jsonString = e.Result.ToString();

                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
                    {
                        var response = new DataContractJsonSerializer(typeof(Place));
                        Place place = (Place)response.ReadObject(ms);

                        city.Name = place.Query.Result.Description.Name;
                        city.Code = place.Query.Result.Description.Woeid;

                        searchCurrentWeather();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Utils.GetMessage("CityNotFoundMessage"));
                    return;
                }
            }
        }

        /// <summary>
        /// Searches the weather using Yahoo's API
        /// </summary>
        private void searchCurrentWeather()
        {
            try
            {
                string url = @"http://query.yahooapis.com/v1/public/yql?q=" + Uri.EscapeDataString("select item.condition.temp, item.condition.text,item.condition.code from weather.forecast where woeid=\"" + city.Code + "\" and u=\"c\" ;") + "&format=json&callback=";            
                WebClient client = new WebClient();
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(searchCurrentWeatherCallback);
                client.DownloadStringAsync(new Uri(url, UriKind.Absolute));
                progressBar.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utils.GetMessage("UnableToRetrieveWeather"));
                return;
            }
        }

        private void searchCurrentWeatherCallback(object sender, DownloadStringCompletedEventArgs e)
        {
            progressBar.Visibility = Visibility.Collapsed;
            if ((e.Result != null) && (e.Error == null))
            {
                try
                {

                    string jsonString = e.Result.ToString();

                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
                    {
                        var response = new DataContractJsonSerializer(typeof(Weather));
                        Weather weather = (Weather)response.ReadObject(ms);
                     
                        city.Condition = weather.Query.Result.Channel.Item.Condition.Text;
                        city.Temperature = weather.Query.Result.Channel.Item.Condition.Temp;
                        city.ConditionCode = weather.Query.Result.Channel.Item.Condition.Code;

                        // saving state and moving to the next page
                        ApplicationStateHelper.SaveCityToAppState(city);

                        NavigationService.Navigate(new Uri("/ShowWeatherPage.xaml", UriKind.Relative));
                    }
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Utils.GetMessage("UnableToRetrieveWeather"));
                    return;
                }
            }
        }

    }
}