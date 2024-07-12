using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface IImageRepository : IBaseRepository<ImageModel>
    {
        Task<ImageModel> GetLast();
        Task<ImageModel> GetByLastLog();

    }
}
