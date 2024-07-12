using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface IGaugeParameterRepository:IBaseRepository<GaugeParameterModel>
    {
        Task<IList<GaugeParameterModel>> GetAllGaugeParameter(string url);
    }
}
