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

namespace MyWeatherApp.Util
{
    public class Utils
    {
        /// <summary>
        /// Helper method that returns the string from the resource file based on the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetMessage(string key)
        {
            return MyWeatherApp.Localization.Localization.ResourceManager.GetString(key,
                MyWeatherApp.Localization.Localization.Culture);
        }
    }
}
