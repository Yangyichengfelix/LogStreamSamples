using Mac2sAPI.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mac2sAPI.Contracts
{
    public interface  ILogRepository:IRepositoryBase<LogDuration>
    {

        Task<IList<LogDuration>> GetNokAlert(DateTime start, DateTime end);
        Task<int> GetNokNumber(DateTime start, DateTime end);
        Task<int> GetCycleTime();
        Task<float> GetObjectifNumberProgress(DateTime start, DateTime end);
        //Task<IList<Log>> GetAllOrigianlLogs(DateTime start, DateTime end);
        Task<IList<LogDuration>> GetSkewingAlert(DateTime start, DateTime end);
        Task<IList<LogDuration>> FindWithTimeRange(DateTime from, DateTime to);

        

    }
}
