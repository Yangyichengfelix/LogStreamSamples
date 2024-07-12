using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IGaugeParameterRepository : IRepositoryBase<GaugeParameter>
    {
        Task<IList<GaugeParameter>> GetAllGaugeParameter();
    }
}
