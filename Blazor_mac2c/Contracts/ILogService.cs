using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface ILogService
    {
        Task<List<LogDurationModel>> GetLogDurations();
    }
}
