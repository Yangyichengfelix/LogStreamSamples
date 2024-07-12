using Mac2sAPI.Data;
using Mac2sAPI.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Services
{
    public class GaugeParameterRepository : IGaugeParameterRepository
    {
        private readonly Mac2sAPIDbContext _db;
        public GaugeParameterRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
        #region unused
        public Task<bool> Create(GaugeParameter entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(GaugeParameter entity)
        {
            throw new NotImplementedException();
        }

        #endregion unused


        public async Task<GaugeParameter> FindById(int id)
        {
            var gauge = await _db.GaugeParameters
                 .FirstOrDefaultAsync(a => a.Id == id);
            return gauge;
        }

        public async Task<IList<GaugeParameter>> GetAllGaugeParameter()
        {
            var gauges = await _db.GaugeParameters.ToListAsync();
            return gauges;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.GaugeParameters.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(GaugeParameter entity)
        {
            _db.GaugeParameters.Update(entity);
            return await Save();
        }
    }
}
