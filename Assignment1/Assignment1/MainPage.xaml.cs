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
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Controls;

namespace Assignment1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// By default, the text blocks will not be visible (Collapsed). When clicking on the button
        /// ShowExplanation this method is executed and it changes the Visibility property of the
        /// text blocks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowExplanationToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShowExplanationToggleButton.IsChecked == true)
            {
                PrivateComputerExplanationTxt.Visibility = Visibility.Visible;
                PublicComputerExplanationTxt.Visibility = Visibility.Visible;
                ShowExplanationToggleButton.Content = GetMessage("HideExplanationLabel");
            }
            else
            {
                PrivateComputerExplanationTxt.Visibility = Visibility.Collapsed;
                PublicComputerExplanationTxt.Visibility = Visibility.Collapsed;
                ShowExplanationToggleButton.Content = GetMessage("ShowExplanationLabel");
            }

        }
        
        /// <summary>
        /// If the user selects the "Private Computer" radio box we show 
        /// the warning message that is initially hidden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrivateComputerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            WarningPrivateComputerTxt.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// If the user unchecks the "Private computer" radio button
        /// we hide the warning message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrivateComputerRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            WarningPrivateComputerTxt.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// In case the "Use Light Version" checkbox is checked
        /// we should show the info text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseLightVersionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UseLightVersionTxt.Visibility = Visibility.Visible;
            UseLightVersionMoreInfoBtn.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// In case the "Use Light Version" checkbox is unchecked
        /// we hide the info text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseLightVersionCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UseLightVersionTxt.Visibility = Visibility.Collapsed;
            UseLightVersionMoreInfoBtn.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Opens in the webbrowser the more info URL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseLightVersionMoreInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask wtb = new WebBrowserTask();
            // retrieving link from the resources file
            String link = GetMessage("UseLightVersionMoreInfoLink");
            wtb.Uri = new Uri(link, UriKind.Absolute);
            
            // triggering web browser to open
            wtb.Show(); 
        }

        /// <summary>
        /// Here we will execute the logic if the user click on the "Sign In" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserNameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (userName != "" && password != "")
            {
                MessageBox.Show(GetMessage("LoginSuccessfulMessage") + " " + userName + "!");
            }
            else
            {
                MessageBox.Show(GetMessage("LoginErrorMessage"));
            }
        }

        /// <summary>
        /// Helper method that returns the string from the resource file based on the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetMessage(string key)
        {
            return Assignment1.Resources.AppResources.ResourceManager.GetString(key,
                Assignment1.Resources.AppResources.Culture);
        }

    }
}