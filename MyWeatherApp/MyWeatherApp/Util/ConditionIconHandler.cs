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
using System.Windows.Media.Imaging;
using MyWeatherApp.Model;

namespace MyWeatherApp.Util
{
    /// <summary>
    /// Returns the icon for the weather based on the
    /// condition. It crops the icon from the Images/Meteocons.jpg.
    /// To do the cropping we use the extension : WrietableBitMap -> http://writeablebitmapex.codeplex.com/
    /// </summary>
    public class ConditionIconHandler
    {
        private WriteableBitmap wBitmap;

        public ConditionIconHandler()
        {
            wBitmap = BitmapFactory.New(1, 1).FromResource("Images/Meteocons.jpg");
        }

        /// <summary>
        /// Returns the correct icon based on the Condition enum
        /// </summary>
        /// <param name="codeCond"></param>
        /// <returns></returns>
        public WriteableBitmap getIconByCondition(City.ConditionEnum codeCond)
        {
            if (codeCond.Equals(City.ConditionEnum.Cloud))
            {
                return getCloudyWeather();
            }
            else if (codeCond.Equals(City.ConditionEnum.Fair))
            {
                return getFairWeather();
            }
            else if (codeCond.Equals(City.ConditionEnum.Fog))
            {
                return getFoggyWeather();
            }
            else if (codeCond.Equals(City.ConditionEnum.Hail))
            {
                return getHailWeather();
            }
            else if (codeCond.Equals(City.ConditionEnum.Rain))
            {
                return getRainyWeather();
            }
            else if (codeCond.Equals(City.ConditionEnum.Snow))
            {
                return getSnowyWeather();
            }
            else if (codeCond.Equals(City.ConditionEnum.Storm))
            {
                return getStormWeather();
            }
            else
            {
                return getSunnyWeather();
            }
        }

        public WriteableBitmap getFairWeather()
        {
            return wBitmap.Crop(333,15,150,128);
        }

        public WriteableBitmap getStormWeather()
        {
            return wBitmap.Crop(20,470, 150, 128);
        }

        public WriteableBitmap getSunnyWeather()
        {
            return wBitmap.Crop(20, 15, 150, 128);
        }

        public WriteableBitmap getHailWeather()
        {
            return wBitmap.Crop(333, 320, 150, 128);
        }

        public WriteableBitmap getCloudyWeather()
        {
            return wBitmap.Crop(20, 170, 150, 128);
        }

        public WriteableBitmap getFoggyWeather()
        {
            return wBitmap.Crop(333, 640, 150, 128);
        }

        public WriteableBitmap getRainyWeather()
        {
            return wBitmap.Crop(333, 170, 150, 128);
        }

        public WriteableBitmap getSnowyWeather()
        {
            return wBitmap.Crop(20, 320, 150, 128);
        }
    }
}
