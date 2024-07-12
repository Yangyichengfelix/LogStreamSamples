using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface IScheduleParameterRepository : IBaseRepository<ScheduleParameterModel>
    {
        Task<IList<ScheduleParameterModel>> GetAllScheduleParameter(string url);
    }
}
