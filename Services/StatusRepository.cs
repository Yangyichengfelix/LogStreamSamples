using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Services
{
    public class StatusRepository : IStatusRepository
    {
        private readonly Mac2sAPIDbContext _db;
        public StatusRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }



        public async Task<IList<Status>> GetStatus()
        {
            var report =  _db.Statuss
                .Include(a => a.StatusGroup)
                .ToList();
            return report;
        }


        #region unused
        public Task<bool> Create(Status entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Status entity)
        {
            throw new NotImplementedException();
        }

        public Task<Status> FindById(int id)
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

        public Task<bool> Update(Status entity)
        {
            throw new NotImplementedException();
        }
        #endregion unused

    }
}
