using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyWeatherApp
{
    /// <summary>
    /// This class is used to access the localization resource files.
    /// </summary>
    public class LocalizationHelper
    {

        public LocalizationHelper()
        {
        }

        private static MyWeatherApp.Localization.Localization localization = new MyWeatherApp.Localization.Localization();

        /// <summary>
        /// Provides access to the localization object
        /// </summary>
        public MyWeatherApp.Localization.Localization Localization { get { return localization; } }

    }
}
