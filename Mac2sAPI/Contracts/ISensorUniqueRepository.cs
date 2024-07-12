using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface ISensorUniqueRepository: IRepositoryBase<SensorUnique>
    {
        Task<IList<SensorUnique>> Sensor1ValueTimeRange(DateTime start, DateTime end);
        Task<IList<SensorUnique>> Sensor2ValueTimeRange(DateTime start, DateTime end);
        Task<IList<SensorUnique>> Sensor3ValueTimeRange(DateTime start, DateTime end);
        Task<IList<SensorUnique>> Sensor4ValueTimeRange(DateTime start, DateTime end);
        Task<IList<SensorUnique>> Sensor5ValueTimeRange(DateTime start, DateTime end);

        Task<SensorUnique> Sensor1RealTime();
        Task<SensorUnique> Sensor2RealTime();
        Task<SensorUnique> Sensor3RealTime();
        Task<SensorUnique> Sensor4RealTime();
        Task<SensorUnique> Sensor5RealTime();


    }
}
