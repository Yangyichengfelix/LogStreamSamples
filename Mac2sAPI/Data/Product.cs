using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mac2sAPI.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]

        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }

        public IList<ProductionOrder> ProductionOrders { get; set; }
        public int? MoldId { get; set; }
        public virtual Mold Mold{ get; set; }
        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }


    }
}
