using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Services
{
    public class ScheduleParameterRepository : IScheduleParameterRepository
    {
        private readonly Mac2sAPIDbContext _db;
        public ScheduleParameterRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(ScheduleParameter entity)
        {
            await _db.ScheduleParameters.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(ScheduleParameter entity)
        {
            _db.ScheduleParameters.Remove(entity);
            return await Save();
        }

        public async Task<ScheduleParameter> FindById(int id)
        {
            var schedule = await _db.ScheduleParameters
                 .FirstOrDefaultAsync(a => a.Id == id);
            return schedule;
        }

        public async Task<IList<ScheduleParameter>> GetAllScheduleParameter()
        {
            return await _db.ScheduleParameters.ToListAsync();
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.ScheduleParameters.AnyAsync(a => a.Id == id);

        }
        public async Task<bool> isOnlyOneLeft()
        {
            return await _db.ScheduleParameters.CountAsync()==1;
        }

        public async Task<bool> CheckTimeValidation(ScheduleParameter entity)
        {
            return entity.Start < entity.End; 
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(ScheduleParameter entity)
        {
            _db.ScheduleParameters.Update(entity);
            return await Save();
        }
    }
}
