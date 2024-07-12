using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Services
{
    public class DurationRepository: IStatusDurationRepository, IStatusGroupDurationRepository
    {
        private readonly Mac2sAPIDbContext _db;
        public DurationRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
#region unused
        public Task<bool> Create(StatusDuration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(StatusGroupDuration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(StatusDuration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(StatusGroupDuration entity)
        {
            throw new NotImplementedException();
        }

        public Task<StatusDuration> FindById(int id)
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

        public Task<bool> Update(StatusDuration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(StatusGroupDuration entity)
        {
            throw new NotImplementedException();
        }

        Task<StatusGroupDuration> IRepositoryBase<StatusGroupDuration>.FindById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion unused
        public async Task<IList<StatusDuration>> GetStatusDurations(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end)
        {
            var startString = start.ToString("s");
            var endString = end.ToString("s");

           
            var scheduleStartString = scheduleStart.ToString();
            var scheduleEndString = scheduleEnd.ToString();
            var result = await _db.StatusDurations.FromSqlRaw($"CALL GetStatusWithDurationBy_TimeRange_schedule('{startString}','{endString}','{scheduleStartString}', '{scheduleEndString}')").ToListAsync();

            return result;
        }



        public async Task<IList<StatusGroupDuration>> GetStatusGroupDuration(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end)
        {
            var startString = start.ToString("s");
            var endString = end.ToString("s");
            var scheduleStartString = scheduleStart.ToString();
            var scheduleEndString = scheduleEnd.ToString();
            var result = await _db.StatusGroupDurations.FromSqlRaw($"CALL GetStatusGroup_WithDuration_ByTimeRange_schedule('{startString}','{endString}','{scheduleStartString}', '{scheduleEndString}')").ToListAsync();

            return result;
        }

        public async Task<float> GetTRG(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end)
        {
            var startString = start.ToString("s");
            var endString = end.ToString("s");
            var scheduleStartString = scheduleStart.ToString();
            var scheduleEndString = scheduleEnd.ToString();


            var tElements = await _db.StatusDurations.FromSqlRaw($"CALL GetStatusWithDurationBy_TimeRange_schedule('{startString}','{endString}','{scheduleStartString}', '{scheduleEndString}')").ToListAsync();
           
            TimeSpan to = end.Subtract(start);
            var tu = tElements.Where(a => (a.Id == 3)).Sum(x => x.Duration);
            float final = 0;
            if (Convert.ToSingle(to.TotalSeconds) != 0)
            {
                var result = Convert.ToSingle(tu) / Convert.ToSingle(to.TotalSeconds);
                final = result;
            }
            return final;

        }

        public async Task<float> GetTRS(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end)
        {
            var startString = start.ToString("s");
            var endString = end.ToString("s");
            var scheduleStartString = scheduleStart.ToString();
            var scheduleEndString = scheduleEnd.ToString();
            var tbfElements = await _db.StatusDurations.FromSqlRaw($"CALL GetStatusWithDurationBy_TimeRange_schedule('{startString}','{endString}','{scheduleStartString}', '{scheduleEndString}')").ToListAsync();
            var tbf = tbfElements.Where(a => (a.Id != 5 || a.Id != 11)).Sum(x => x.Duration);    
            var tu = tbfElements.Where(a => (a.Id == 3)).Sum(x => x.Duration);
            float final = 0;
            if (Convert.ToSingle(tbf) != 0)
            {
                var result = Convert.ToSingle(tu) / Convert.ToSingle(tbf);
                final=result;
            }
            return final;
        }


    }
}
