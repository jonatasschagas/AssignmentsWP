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

namespace MyWeatherApp.Model
{
    /// <summary>
    /// Object used to encapsulate all the data that is transported in the pages
    /// of the application. It has the city and weather data.
    /// </summary>
    public class City
    {

        public static readonly string KEY = "city";

        public string Name { get; set; }
        public string Code { get; set; }
        public string ConditionCode { get; set; }
        public string Temperature { get; set; }
        public string Condition { get; set; }

        public enum ConditionEnum { Storm, Snow, Rain, Hail, Sun, Cloud, Fog, Fair };
        
        /// <summary>
        /// Returns the enum value according to the weather condition code
        /// See: http://developer.yahoo.com/weather/#item - Condition Codes
        /// </summary>
        /// <returns></returns>
        public ConditionEnum getConditionEnum()
        {
            ConditionEnum cond = ConditionEnum.Sun;

            if (ConditionCode == "0" || ConditionCode == "1"
                || ConditionCode == "2" || ConditionCode == "3"
                || ConditionCode == "4")
            {
                cond = ConditionEnum.Storm;
            }
            else if (ConditionCode == "5" || ConditionCode == "6"
                || ConditionCode == "7" || ConditionCode == "8"
                || ConditionCode == "9" || ConditionCode == "10"
                || ConditionCode == "11" || ConditionCode == "12")
            {
                cond = ConditionEnum.Rain;
            }
            else if (ConditionCode == "13" || ConditionCode == "14"
                || ConditionCode == "15" || ConditionCode == "16")
            {
                cond = ConditionEnum.Snow;
            }
            else if (ConditionCode == "17" || ConditionCode == "18")
            {
                cond = ConditionEnum.Hail;
            }
            else if (ConditionCode == "19" || ConditionCode == "20"
                || ConditionCode == "21" || ConditionCode == "22")
            {
                cond = ConditionEnum.Fog;
            }
            else if (ConditionCode == "26" || ConditionCode == "27"
                || ConditionCode == "28" || ConditionCode == "29"
                || ConditionCode == "30")
            {
                cond = ConditionEnum.Cloud;
            }
            else if (ConditionCode == "31" || ConditionCode == "32")
            {
                cond = ConditionEnum.Sun;
            }
            else if (ConditionCode == "33" || ConditionCode == "34")
            {
                cond = ConditionEnum.Fair;
            }

            return cond;       
        }
    }
}
