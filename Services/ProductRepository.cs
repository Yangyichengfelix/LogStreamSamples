using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Services
{
    public class ProductRepository: IProductRepository
    {
        private readonly Mac2sAPIDbContext _db;
        public ProductRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
        #region unused
        public Task<bool> Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        #endregion unused

        public async Task<Product> FindById(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<IList<Product>> FindAll()
        {
            return  await _db.Products.ToListAsync();
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Products.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Product entity)
        {
            _db.Products.Update(entity);
            return await Save();
        }
    }
}
