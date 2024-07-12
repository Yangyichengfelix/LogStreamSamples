using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface IStatusGroupDurationRepository
    {
        public Task<IList<StatusGroupDurationModel>> GetStatusGroupDuration(string url);
    }
}
