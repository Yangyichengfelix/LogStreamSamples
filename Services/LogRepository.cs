using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mac2sAPI.Services
{
    public class LogRepository : ILogRepository

    {
        private readonly Mac2sAPIDbContext _db;
        public LogRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
        public async Task<IList<LogDuration>> FindWithTimeRange(DateTime start, DateTime end)
        {
            var logs = await _db.LogDurations
                .Include(a => a.Status)
                .Where(t=>(t.Date_Heure>=start && t.Date_Heure <= end)) 
                .ToListAsync();
            return logs;
        }
        public async Task<IList<LogDuration>> GetNokAlert(DateTime start, DateTime end)
        {
            var logs = await _db.LogDurations
               .Include(a => a.Status)
               
               .Where(t => (t.Date_Heure >= start && t.Date_Heure <= end))
               .Where(t =>t.NOK!=0)
               .ToListAsync();
            return logs;
        }
        public async Task<IList<LogDuration>> GetSkewingAlert(DateTime start, DateTime end)
        {
           
            
            var logs = await _db.LogDurations
            .Include(a => a.Status)
            //.Include(a=>a.ProductionOrder.Product.Mold)
            .Where(t => (t.Date_Heure >= start && t.Date_Heure <= end))
            .Where(t => (t.Abs_Val_S1_microm >t.Hi_Tol_S1
                     || t.Abs_Val_S2_microm > t.Hi_Tol_S2 
                     || t.Abs_Val_S3_microm > t.Hi_Tol_S3
                     || t.Abs_Val_S4_microm > t.Hi_Tol_S4 
                     || t.Abs_Val_S5_microm > t.Hi_Tol_S5 
                     || t.Abs_Val_S1_microm < t.Lo_Tol_S1 
                     || t.Abs_Val_S2_microm < t.Lo_Tol_S2
                     || t.Abs_Val_S3_microm < t.Lo_Tol_S3 
                     || t.Abs_Val_S4_microm < t.Lo_Tol_S4
                     || t.Abs_Val_S5_microm < t.Lo_Tol_S5 
                    ))
            .ToListAsync();
            
            return logs;
        }
        public async Task<int> GetCycleTime()
        {
            var log = await _db.LogDurations
                .Where(t=>t.StatusId==3)
                .OrderBy(a => a.Id)
                .LastOrDefaultAsync();
            var log_n1=await _db.LogDurations
                .Where(a=>a.Id==log.Id-1)
                .FirstOrDefaultAsync();
            Console.WriteLine(log_n1.Id + " "+ log_n1.Duration);
            return  Convert.ToInt32(Math.Floor(log_n1.Duration));
        }

        public async Task<int> GetNokNumber(DateTime start, DateTime end)
        {
            var result = await _db.LogDurations
            .Where(t => (t.Date_Heure >= start && t.Date_Heure <= end))
            .Where(t => t.NOK != 0)
            .CountAsync();

            return result;

        }
        public async Task<float> GetObjectifNumberProgress(DateTime start, DateTime end)
        {
            var  lastOF=  _db.ProductionOrders.OrderBy(of => of.Id).LastOrDefault();
            var productionLogs =  _db.LogDurations
            .Where(t => (t.Date_Heure >= start && t.Date_Heure <= end))
            .Where(t=>t.ProductionOrderId==lastOF.Id)
            .Where(t => t.StatusId == 3)
            .Count();
            var objectif = lastOF.ObjectifNumber;
            float result = 0;
            result = (Convert.ToSingle(productionLogs) / Convert.ToSingle(objectif));
            return result ;
            
        }

        #region unused
        public Task<IList<LogDuration>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<LogDuration> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(LogDuration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(LogDuration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(LogDuration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }





        #endregion unused

    }
}
