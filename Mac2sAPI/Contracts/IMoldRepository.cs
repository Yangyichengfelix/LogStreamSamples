using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IMoldRepository:IRepositoryBase<Mold>
    {
        Task<Mold> GetLastMold();
    }
}
