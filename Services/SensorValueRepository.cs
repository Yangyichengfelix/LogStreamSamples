using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mac2sAPI.Services
{
    public class SensorValueRepository : ISensorUniqueRepository, ISensorPlRepository, ISensorGlobalRepository
    {
        private readonly Mac2sAPIDbContext _db;
        public SensorValueRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
        #region unused
        public Task<SensorUnique> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(SensorUnique entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SensorUnique entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(SensorUnique entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        Task<SensorPl> IRepositoryBase<SensorPl>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(SensorPl entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SensorPl entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(SensorPl entity)
        {
            throw new NotImplementedException();
        }

        Task<SensorGlobal> IRepositoryBase<SensorGlobal>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(SensorGlobal entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SensorGlobal entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(SensorGlobal entity)
        {
            throw new NotImplementedException();
        }
        #endregion unused

        public async Task<IList<SensorGlobal>> SensorGlobalValueTimeRange(DateTime start, DateTime end)
        {
            var values = (from a in _db.LogDurations
                          where (a.Date_Heure >= start && a.Date_Heure <= end)
                          select new SensorGlobal
                          {
                              Date_Heure = a.Date_Heure,
                              V1 = a.Abs_Val_S1_microm,
                              V2 = a.Abs_Val_S2_microm,
                              V3 = a.Abs_Val_S3_microm,
                              V4 = a.Abs_Val_S4_microm,
                              V5 = a.Abs_Val_S5_microm,
                              Vp = a.Abs_Val_PL,
                              TH1 = a.Hi_Tol_S1,
                              TH2 = a.Hi_Tol_S2,
                              TH3 = a.Hi_Tol_S3,
                              TH4 = a.Hi_Tol_S4,
                              TH5 = a.Hi_Tol_S5,
                              TL1 = a.Lo_Tol_S1,
                              TL2 = a.Lo_Tol_S2,
                              TL3 = a.Lo_Tol_S3,
                              TL4 = a.Lo_Tol_S4,
                              TL5 = a.Lo_Tol_S5,
                          }).ToListAsync();
            return await values;
        }
        public async Task<IList<SensorPl>> SensorPlValueTimeRange(DateTime start, DateTime end)
        {
            
            var values = (from a in _db.LogDurations
                          where ((a.Date_Heure >= start && a.Date_Heure <= end) && (a.Abs_Val_PL != null))
                          select new SensorPl { Date_Heure = a.Date_Heure, Value = a.Abs_Val_PL }).ToListAsync();
            return await values;
        }

        public async Task<IList<SensorUnique>> Sensor1ValueTimeRange(DateTime start, DateTime end)
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          where ((a.Date_Heure >= start && a.Date_Heure <= end) && (a.Abs_Val_S1_microm !=  null))
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S1_microm, High=a.Hi_Tol_S1+ md.Ref_S1, Low=a.Lo_Tol_S1 + md.Ref_S1 }).ToListAsync();
            return await values;
        }

        public async Task<IList<SensorUnique>> Sensor2ValueTimeRange(DateTime start, DateTime end)
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
         
            var values = (from a in _db.LogDurations
                          where ((a.Date_Heure >= start && a.Date_Heure <= end) && (a.Abs_Val_S2_microm != null))
                          
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S2_microm, High = a.Hi_Tol_S2 + md.Ref_S2, Low = a.Lo_Tol_S2 + md.Ref_S2 }).ToListAsync();
           

            return await values;
        }

        public async Task<IList<SensorUnique>> Sensor3ValueTimeRange(DateTime start, DateTime end)
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          where ((a.Date_Heure >= start && a.Date_Heure <= end) && (a.Abs_Val_S3_microm != null))
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S3_microm, High = a.Hi_Tol_S3+ md.Ref_S3, Low = a.Lo_Tol_S3 + md.Ref_S3 }).ToListAsync();
            return await values;
        }
        public async Task<IList<SensorUnique>> Sensor4ValueTimeRange(DateTime start, DateTime end)
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          where ((a.Date_Heure >= start && a.Date_Heure <= end) && (a.Abs_Val_S4_microm != null))
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S4_microm, High = a.Hi_Tol_S4+md.Ref_S4, Low = a.Lo_Tol_S4 + md.Ref_S4 }).ToListAsync();
            return await values;
        }
        public async Task<IList<SensorUnique>> Sensor5ValueTimeRange(DateTime start, DateTime end)
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          where ((a.Date_Heure >= start && a.Date_Heure <= end) && (a.Abs_Val_S5_microm != null))
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S5_microm, High = a.Hi_Tol_S5+ md.Ref_S5, Low = a.Lo_Tol_S5 + md.Ref_S5 }).ToListAsync();
            return await values;
        }

        public async Task<SensorUnique> Sensor1RealTime()
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          orderby a.Date_Heure descending
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S1_microm, High = a.Hi_Tol_S1+md.Ref_S1, Low = a.Lo_Tol_S1 + md.Ref_S1 }).Take(1);
            return await values.LastAsync();
        }

        public async Task<SensorUnique> Sensor2RealTime()
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          orderby a.Date_Heure descending
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S2_microm, High = a.Hi_Tol_S2 + md.Ref_S2, Low = a.Lo_Tol_S2 + md.Ref_S2 }).Take(1);
            return await values.LastAsync();
        }

        public async Task<SensorUnique> Sensor3RealTime()
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          orderby a.Date_Heure descending
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S3_microm, High = a.Hi_Tol_S3 + md.Ref_S3, Low = a.Lo_Tol_S3 + md.Ref_S3 }).Take(1);
            return await values.LastAsync();
        }
        public async Task<SensorUnique> Sensor4RealTime()
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          orderby a.Date_Heure descending
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S4_microm, High = a.Hi_Tol_S4 + md.Ref_S4, Low = a.Lo_Tol_S4 + md.Ref_S4 }).Take(1);
            return await values.LastAsync();
        }
        public async Task<SensorUnique> Sensor5RealTime()
        {
            var md = _db.Machines.OrderBy(mold=>mold.Id).LastOrDefault();
            var values = (from a in _db.LogDurations
                          orderby a.Date_Heure descending
                          select new SensorUnique { Date_Heure = a.Date_Heure, Value = a.Abs_Val_S5_microm, High = a.Hi_Tol_S5 + md.Ref_S5, Low = a.Lo_Tol_S5 + md.Ref_S5}).Take(1);
            return await values.LastAsync();
        }

        public async Task<SensorPl> SensorPlRealTime()
        {
            var values = (from a in _db.LogDurations
                          orderby a.Date_Heure descending
                          select new SensorPl { Date_Heure = a.Date_Heure, Value = a.Abs_Val_PL }).Take(1);
            return await values.LastAsync();
        }
    }
}
