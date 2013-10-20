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
using Microsoft.Phone.Shell;
using MyWeatherApp.Model;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Serialization;

namespace MyWeatherApp.Util
{
    /// <summary>
    /// Handles all the state related operations in the App
    /// </summary>
    public class ApplicationStateHelper
    {

        /// <summary>
        /// Saves the state of the app by storing the city object
        /// </summary>
        /// <param name="city"></param>
        public static void SaveCityToAppState(City city)
        {
            PhoneApplicationService.Current.State[City.KEY] = city;
        }

        /// <summary>
        /// Loads the city object in order to recover the state of the app
        /// </summary>
        /// <returns></returns>
        public static City LoadCityFromAppState()
        {
            if (PhoneApplicationService.Current.State.ContainsKey(City.KEY))
            {
                return PhoneApplicationService.Current.State[City.KEY] as City;
            }
            return null;
        }
        
        /// <summary>
        /// Loads the object from Local storage
        /// </summary>
        /// <returns></returns>
        public static City LoadCityFromIsolatedStorage()
        {
            // load the view model from isolated storage
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var stream = new IsolatedStorageFileStream("data.txt", FileMode.OpenOrCreate, FileAccess.Read, store))
            using (var reader = new StreamReader(stream))
            {
                if (!reader.EndOfStream)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(City));
                    return (City)serializer.Deserialize(reader);
                }
            }

            return null;
        }

        /// <summary>
        /// Saves the city object to local storage
        /// </summary>
        /// <param name="city"></param>
        public static void SaveCityToIsolatedStorage(City city)
        {
            // persist the data using isolated storage
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var stream = new IsolatedStorageFileStream("data.txt",
                                                            FileMode.Create,
                                                            FileAccess.Write,
                                                            store))
            {
                var serializer = new XmlSerializer(typeof(City));
                serializer.Serialize(stream, city);
            }
        }
    }
}
