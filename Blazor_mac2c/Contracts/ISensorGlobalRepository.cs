using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface ISensorGlobalRepository: IBaseRepository<SensorGlobalModel>
    {
        Task<IList<SensorGlobalModel>> GetValues(string url);
    }
}
