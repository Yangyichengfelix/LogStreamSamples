using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mac2sAPI.Services
{
    public class ActivityReportRepository : IActivityReportRepository

    {
        private readonly Mac2sAPIDbContext _db;
        public ActivityReportRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
#region unused
        public Task<bool> Create(ActivityReport entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ActivityReport entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActivityReport> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ActivityReport entity)
        {
            throw new NotImplementedException();
        }
#endregion unused

        public async Task<IList<ActivityReport>> GetActivityReport(DateTime start, DateTime end)
        {
            var startString = start.ToString("s");
            var endString = end.ToString("s");
            var report = await _db.ActivityReports.FromSqlRaw($"CALL GetGroupedStatusByTimeRange('{startString}','{endString}')").ToListAsync();
            return report;
        }


    }
}
