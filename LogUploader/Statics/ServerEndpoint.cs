using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Statics
{
    public class ServerEndpoint
    {
//#if DEBUG
//        public static string BaseUrl = "https://localhost:7050/";
//#endif
//#if Release
//#endif
        public static string BaseUrl = "http://192.168.1.50:8081/";
        public static string LoginEndpoint = $"{BaseUrl}api/auth/login/";

        //public static string GetLogsEndpoint = $"{BaseUrl}api/log/upload/timerange";
        //public static string CreateLogEndpoint = $"{BaseUrl}api/log/create";
        public static string CreateLogsEndpoint = $"{BaseUrl}api/log/createlogs";

    }
}
