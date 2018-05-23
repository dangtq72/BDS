using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starts_Service
{
    public class ConfigInfo
    {
        public static string ConnectionString = "";
        public static string UpdatePath = "";

        public static void GetConfig()
        {
            ConnectionString = System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionString").ToString();
            UpdatePath = System.Configuration.ConfigurationManager.AppSettings["UpdatePath"];
        }
    }
}
