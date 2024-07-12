using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mac2sAPI.Data
{
    [Table("ScheduleParameter")]
    public class ScheduleParameter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

    }
}
