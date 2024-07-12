using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Mac2sAPI.Data
{
    [Table("StatusGroup")]

    public class StatusGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Status> Statuss { get; set; }
        [MaxLength(15)]
        public string Color { get; set; } // added 27/01/2022
    }
}
