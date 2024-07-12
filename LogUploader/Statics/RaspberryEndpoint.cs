using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Statics
{
    public class RaspberryEndpoint
    {
#if DEBUG
        public static string BaseUrl = "https://localhost:7064/";
        //#endif
        //#if ERMO
        //        public static string BaseUrl = "https://localhost:7064/";
        //#endif
#elif Release
        public static string BaseUrl = "http://192.168.1.40:8081/";
#endif
        public static string LoginEndpoint = $"{BaseUrl}api/auth/login/";
        public static string GetLogsEndpoint = $"{BaseUrl}api/log/rawlogs/timerange";

    }
}
