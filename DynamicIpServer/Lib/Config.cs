using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Lib
{
    public class Config
    {
        private static readonly string _serverIpKeyName = "ServerIp";
        private static readonly string _serverPort      = "ServerPort";
        private static          string _serverIp;
        private static          string _companyIp = "companyIp";
        public static string GetConfig(string name, string defaultVal = "")
        {
            var val = ConfigurationManager.AppSettings[name];
            if (string.IsNullOrEmpty(val))
                return defaultVal;
            return val;
        }

        public static void SaveConfig(string name, string value = "")
        {
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           
            var key = config.AppSettings.Settings[name];
            if (key == null)
            {
                config.AppSettings.Settings.Add(name, value);

            }
            else
            {
                key.Value = value;

            }
            config.Save(ConfigurationSaveMode.Modified);
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");

        }

        public static string GetServerIp()
        {
            var ip = GetConfig(_serverIpKeyName);
            return ip;
        }

        public static string GetServerPort()
        {
            var ip = GetConfig(_serverPort);
            return ip;
        }

        public static void SaveServerIp(string servierip, string port)
        {
            SaveConfig(_serverIpKeyName, servierip);
            SaveConfig(_serverPort,      servierip);
        }

        public static string GetCompanyIp()
        {
            var ip = GetConfig(_companyIp,"NoIp");
            return ip;
        }
        public static void SaveCompanyIp(string servierip)
        {
            SaveConfig(_companyIp,  servierip);

        }
    }
}
