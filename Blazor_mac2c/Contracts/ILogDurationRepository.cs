using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface ILogDurationRepository:IBaseRepository<LogDurationModel>
    {
        public Task<IList<LogDurationModel>> GetLogDuration(string url);
        public Task<IList<LogDurationModel>> GetNokAlert(string url);
        public Task<IList<LogDurationModel>> GetSkewingAlert(string url);

        public Task<int?> GetNokNumber(string url);
        public Task<int?> GetCycleTime(string url);

    }
}
