using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IStatusGroupDurationRepository:IRepositoryBase<StatusGroupDuration>
    {
        Task<IList<StatusGroupDuration>> GetStatusGroupDuration(TimeSpan scheduleStart, TimeSpan  scheduleEnd, DateTime start, DateTime end);
    }
}
