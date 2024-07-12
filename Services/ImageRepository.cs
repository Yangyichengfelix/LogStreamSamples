using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Services
{
    public class ImageRepository : IImageRepository
    {

        private readonly Mac2sAPIDbContext _db;
        public ImageRepository(Mac2sAPIDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Image entity)
        {
            await _db.Images.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Image entity)
        {
            _db.Images.Remove(entity);
            return await Save();
        }

        public async Task<Image> FindById(int id)
        {
            var img = await _db.Images
          .FirstOrDefaultAsync(a => a.Id == id);
            return img;
        }

        public async Task<Image> FindImageByLastLog()
        {
            var log = _db.LogDurations.OrderBy(l=>l.Date_Heure).Last();
            var order = _db.ProductionOrders.Where(po => po.Id == log.ProductionOrderId).FirstOrDefault();
            var product = _db.Products.Where(p => p.Id == order.ProductId).FirstOrDefault();
            var image = _db.Images.Where(img => img.Id == product.ImageId).FirstOrDefaultAsync();
            return await image;
        }

        public async Task<Image> FindImageByLogId(int id)
        {
            var log = _db.LogDurations.Where(log => log.Id == id).FirstOrDefault();
            var order = _db.ProductionOrders.Where(po => po.Id == log.ProductionOrderId).FirstOrDefault();
            var product = _db.Products.Where(p => p.Id == order.ProductId).FirstOrDefault();
            var image = _db.Images.Where(img => img.Id == product.ImageId).FirstOrDefaultAsync();
            return await image;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Images.AnyAsync(a => a.Id == id);
        }

        public async Task<Image> LastImage()
        {
            return await _db.Images.OrderBy(a=>a.Id).LastAsync();
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Image entity)
        {
            _db.Images.Update(entity);
            return await Save();
        }
    }
}
