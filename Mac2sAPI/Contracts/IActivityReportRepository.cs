using Mac2sAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mac2sAPI.Contracts
{
    public interface IActivityReportRepository:IRepositoryBase<ActivityReport>
    {
        Task<IList<ActivityReport>> GetActivityReport(DateTime start, DateTime end);
    }
}
