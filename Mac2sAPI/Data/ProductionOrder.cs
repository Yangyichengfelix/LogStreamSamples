using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mac2sAPI.Data
{
    [Table("ProductionOrder")]
    public class ProductionOrder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Reference { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? Color { get; set; }
        public int ObjectifNumber { get; set; }
        public string? Material { get; set; }
        public IList<Log> Logs { get; set; }
    }
}
