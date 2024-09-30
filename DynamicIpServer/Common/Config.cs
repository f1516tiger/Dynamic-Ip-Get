using System;

namespace Common
{
    public class Config
    {
        public static string GetConfig(string name, string defaultVal = "")
        {
            var val = ConfigurationManager.AppSettings[name];
            if (string.IsNullOrEmpty(val))
                return defaultVal;
            return val;
        }
    }
}
