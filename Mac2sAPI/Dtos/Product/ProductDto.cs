using Mac2sAPI.Dtos.Image;
using Mac2sAPI.Dtos.Mold;
using Mac2sAPI.Dtos.ProductionOrder;

namespace Mac2sAPI.Dtos.Product
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public int? MoldId { get; set; }
        public string MoldReference { get; set; }
        public int? ImageId { get; set; }


        public virtual IList<ProductionOrderDto> ProductionOrders { get; set; }
        public virtual MoldDto Mold { get; set; }


        public virtual ImageDto ImageDto { get; set; }
    }
}
