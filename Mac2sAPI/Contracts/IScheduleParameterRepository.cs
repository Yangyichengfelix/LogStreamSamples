using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IScheduleParameterRepository : IRepositoryBase<ScheduleParameter>
    {
        Task<IList<ScheduleParameter>> GetAllScheduleParameter();
        Task<bool> isOnlyOneLeft();
        Task<bool> CheckTimeValidation(ScheduleParameter entity);

    }
}
