using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface ISensorPlRepository: IRepositoryBase<SensorPl>
    {
        Task<IList<SensorPl>> SensorPlValueTimeRange(DateTime from, DateTime to);
        Task<SensorPl> SensorPlRealTime();

    }
}
