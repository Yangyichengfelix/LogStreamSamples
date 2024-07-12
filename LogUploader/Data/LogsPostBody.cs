using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Data
{
    public class LogsPostBody
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DbName { get; set; }
        public List<Mac2s_log> LogCreateDtos { get; set; }
        public LogsPostBody(string userName, string pwd, string dbName, List<Mac2s_log> logs)
        {
            UserName = userName;
            Password = pwd;
            DbName = dbName;
            LogCreateDtos=logs;
        }
    }
}
