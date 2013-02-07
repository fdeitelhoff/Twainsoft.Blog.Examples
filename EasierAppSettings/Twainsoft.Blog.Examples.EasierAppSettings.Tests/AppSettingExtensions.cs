using System.ComponentModel;
using System.Configuration;

namespace Twainsoft.Blog.Examples.EasierAppSettings.Tests
{
    public static class AppSettingExtensions
    {
        public static string AppSetting(this string key)
        {
            var value = "";

            if (ConfigurationManager.AppSettings[key] != null)
            {
                value = ConfigurationManager.AppSettings[key];
            }

            return value;
        }

        public static T AppSetting<T>(this string key)
        {
            var value = default(T);

            if (ConfigurationManager.AppSettings[key] != null)
            {
                var converter = TypeDescriptor.GetConverter(typeof (T));

                value = (T)converter.ConvertFrom(ConfigurationManager.AppSettings[key]);
            }

            return value;
        }
    }
}
