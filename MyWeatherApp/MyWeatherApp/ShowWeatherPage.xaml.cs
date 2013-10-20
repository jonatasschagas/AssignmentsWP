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
using Microsoft.Phone.Shell;
using MyWeatherApp.Model;
using MyWeatherApp.Util;

namespace MyWeatherApp
{
    public partial class ShowWeather : PhoneApplicationPage
    {
        
        PhoneApplicationService service = PhoneApplicationService.Current;
        private City city;
        private Weather weather;
        private ConditionIconHandler conditionIconHandler = new ConditionIconHandler();
        public ShowWeather()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the city from the state and populates the screen
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            try
            {
                city = ApplicationStateHelper.LoadCityFromAppState();
                    
                if (city != null)
                {
                    cityTextBox.Text = city.Name;
                    conditionValue.Text = city.Condition;
                    temperatureValue.Text = city.Temperature;
                    conditionImage.Source = conditionIconHandler.getIconByCondition(city.getConditionEnum());
                }
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show(Utils.GetMessage("UnableToRetrieveWeather"));
            }

            base.OnNavigatedTo(e);

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
    }
}