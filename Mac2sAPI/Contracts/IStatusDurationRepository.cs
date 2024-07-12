using Mac2sAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Mac2sAPI.Contracts
{
    public interface IStatusDurationRepository: IRepositoryBase<StatusDuration>
    {
        Task<IList<StatusDuration>> GetStatusDurations(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end);

        Task<float> GetTRG(TimeSpan scheduleStart, TimeSpan scheduleEnd  ,DateTime start, DateTime end);
        Task<float> GetTRS(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end);

    }
}
