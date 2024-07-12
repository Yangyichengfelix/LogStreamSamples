using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface ISensorGlobalRepository:IRepositoryBase<SensorGlobal>
    {
        Task<IList<SensorGlobal>> SensorGlobalValueTimeRange(DateTime from, DateTime to);
    }
}
