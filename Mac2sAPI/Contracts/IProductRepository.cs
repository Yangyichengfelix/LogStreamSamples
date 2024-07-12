using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        Task<IList<Product>> FindAll();
    }
}
