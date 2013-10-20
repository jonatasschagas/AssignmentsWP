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
using System.Runtime.Serialization;
using System.Text;

namespace MyWeatherApp.Model
{
    /// <summary>
    /// Object used to encapsulate the values from the Yahoo Weather API
    /// See: http://developer.yahoo.com/weather/#item
    /// </summary>
    [DataContract]  
    public class Weather
    {
        [DataMember(Name = "query")]
        public QueryWeather Query { get; set; }
    }

    [DataContract]
    public class QueryWeather
    {
        [DataMember(Name = "results")]
        public ResultWeather Result { get; set; }
    }

    [DataContract]
    public class ResultWeather
    {
        [DataMember(Name = "channel")]
        public Channel Channel { get; set; }
    }

    [DataContract]
    public class Channel
    {
        [DataMember(Name = "item")]
        public Item Item { get; set; }
    }

    [DataContract]
    public class Item
    {
        [DataMember(Name = "condition")]
        public Condition Condition { get; set; }
    }

    [DataContract]
    public class Condition
    {
        [DataMember(Name = "temp")]
        public string Temp { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }
    }

}
