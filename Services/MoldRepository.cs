using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Services
{
    public class MoldRepository: IMoldRepository
    {
        private readonly Mac2sAPIDbContext _db;
        public MoldRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
        public async Task<Mold> GetLastMold()
        {
            return await _db.Machines.LastOrDefaultAsync();
        }
        #region unused
        public Task<bool> Create(Mold entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Mold entity)
        {
            throw new NotImplementedException();
        }

        public Task<Mold> FindById(int id)
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

        public Task<bool> Update(Mold entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
