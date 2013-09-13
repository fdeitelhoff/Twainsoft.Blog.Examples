// **************************************************
// 
// Written by Fabian Deitelhoff, 2013-09-13
// http://www.fabiandeitelhoff.de
// 
// **************************************************

using System.ComponentModel;
using System.Configuration;

namespace Twainsoft.Blog.Examples.EasierAppSettings.Tests
{
    public static class AppSettingExtensions
    {
        /// <summary>
        ///     Returns an application setting as string for the given key.
        /// </summary>
        /// <param name="key">The key for the application setting.</param>
        /// <returns></returns>
        public static string AppSetting(this string key)
        {
            var value = "";

            if (ConfigurationManager.AppSettings[key] != null)
            {
                value = ConfigurationManager.AppSettings[key];
            }

            return value;
        }

        /// <summary>
        ///     Returns an application setting as user defined type for the given key.
        /// </summary>
        /// <typeparam name="T">The requested return type for the setting.</typeparam>
        /// <param name="key">The key for the application setting.</param>
        /// <returns></returns>
        public static T AppSetting<T>(this string key)
        {
            var value = default(T);

            if (ConfigurationManager.AppSettings[key] != null)
            {
                var converter = TypeDescriptor.GetConverter(typeof (T));

                value = (T) converter.ConvertFrom(ConfigurationManager.AppSettings[key]);
            }

            return value;
        }
    }
}