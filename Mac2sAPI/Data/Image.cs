using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mac2sAPI.Data
{
    [Table("Image")]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[]? FileContent { get; set; }
        public IList<Product> Products { get; set; }
    }
}
