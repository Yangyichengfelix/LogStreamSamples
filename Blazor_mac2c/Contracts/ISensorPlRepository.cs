using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface ISensorPlRepository
    {
        Task<SensorBaseModel> GetPlRealTime(string url);

    }
}
