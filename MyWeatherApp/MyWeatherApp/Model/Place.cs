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
    /// Object used to encapsulate the Places from Yahoo Places API.
    /// See: http://developer.yahoo.com/geo/geoplanet/guide/yql-tables.html#geo-places
    /// </summary>
    [DataContract]
    public class Place
    {

        [DataMember(Name = "query")]
        public Query Query { get; set; }

    }

    [DataContract]
    public class Query
    {
        [DataMember(Name = "results")]
        public Result Result { get; set; }
    }

    [DataContract]
    public class Result
    {
        [DataMember(Name = "place")]
        public Description Description { get; set; }
    }

    [DataContract]
    public class Description
    {
        [DataMember(Name = "woeid")]
        public string Woeid { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

}

