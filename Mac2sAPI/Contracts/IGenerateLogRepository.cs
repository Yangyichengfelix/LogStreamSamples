using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IGenerateLogRepository:IRepositoryBase<Log>
    {
        Task<IList<Log>> FindWithTimeRange(DateTime from, DateTime to);
        Task<bool> CreateLogs(List<Log> logs);

    }
}
