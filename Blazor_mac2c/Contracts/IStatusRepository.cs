using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface IStatusRepository : IBaseRepository<StatusSimpleModel>
    {
        public Task<IList<StatusSimpleModel>> GetStatusList(string url);
    }
}
