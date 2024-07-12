using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Mac2sAPI.Data
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Log> Logs { get; set; }
        [ForeignKey("StatusGroup")]
        public int StatusGroupId { get; set; }
        public virtual StatusGroup StatusGroup { get; set; }
        [MaxLength(15)]
        public string Color { get; set; } // added 27/01/2022

    }
}
