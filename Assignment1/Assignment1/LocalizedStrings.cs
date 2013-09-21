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

namespace Assignment1
{   
    /// <summary>
    /// This class is used to access the localization resource files.
    /// </summary>
    public class LocalizedStrings
    {

        public LocalizedStrings()
        {
        }

        private static Assignment1.Resources.AppResources localizedresources = new Assignment1.Resources.AppResources();

        /// <summary>
        /// Provides access to the localization object
        /// </summary>
        public Assignment1.Resources.AppResources LocalizedResources { get { return localizedresources; } }

    }
}
