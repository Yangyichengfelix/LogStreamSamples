using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IStatusRepository: IRepositoryBase<Status>
    {
        Task<IList<Status>> GetStatus();
    }
}
