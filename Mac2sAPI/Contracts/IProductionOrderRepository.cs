using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IProductionOrderRepository : IRepositoryBase<ProductionOrder>
    {
        Task<IList<ProductionOrder>> FindAll();

    }
}
