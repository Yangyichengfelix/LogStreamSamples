using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface IStatusDurationRepository
    {
        public Task<IList<StatusDurationModel>> GetStatusDuration(string url);

    }
}
