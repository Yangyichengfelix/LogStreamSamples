using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mac2sAPI.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {

        Task<T> FindById(int id);
        Task<bool> isExists(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }
}
