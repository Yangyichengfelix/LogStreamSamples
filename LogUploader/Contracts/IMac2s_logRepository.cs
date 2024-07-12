using LogUploader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Contracts
{
    public interface IMac2s_logRepository:IBaseRepository<Mac2s_log>
    {
        Task<IList<Mac2s_log>> GetMac2sLog(string getUrl,DateTime start, DateTime end,string loginUrl, string username, string password);
        Task<bool> CreateLog(string url, string username, string password, Mac2s_log log);
        Task<bool> CreateLogs(string url, string username, string password, LogsPostBody postBody);

    }
}
