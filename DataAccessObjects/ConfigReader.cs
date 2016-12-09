using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
  public static  class ConfigReader
    {
        public static string GetConnectionString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static string GetConfigValue(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            return ConfigurationManager.AppSettings[key];
        }
    }
}
