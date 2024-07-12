using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface IActivityReportRepository: IBaseRepository<ActivityReportModel>
    {
        public  Task<IList<ActivityReportModel>> GetActivityReport(string url);
    }
}
