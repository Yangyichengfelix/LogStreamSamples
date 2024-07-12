using Mac2sAPI.Data;

namespace Mac2sAPI.Contracts
{
    public interface IImageRepository:IRepositoryBase<Image>
    {
        Task<Image> LastImage();
        Task<Image> FindImageByLogId(int id);
        Task<Image> FindImageByLastLog();

    }
}
