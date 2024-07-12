using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Services
{
    public class GenerateLogRepository : IGenerateLogRepository
    {
        private readonly Mac2sAPIDbContext _db;
        public GenerateLogRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Log entity)
        {
            await _db.Logs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> CreateLogs(List<Log> logs)
        {
            try
            {
                foreach (var item in logs)
                {
                    await  _db.Logs.AddAsync(item);
                    await Save();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

             
        }

        public Task<bool> Delete(Log entity)
        {
            throw new NotImplementedException();
        }

        public Task<Log> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Log>> FindWithTimeRange(DateTime from, DateTime to)
        {

                var logs = await _db.Logs
    //.Include(a => a.Status)
    .Where(t => (t.Date_Heure >= from && t.Date_Heure <= to))
    .ToListAsync();
                return logs;


        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public Task<bool> Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
