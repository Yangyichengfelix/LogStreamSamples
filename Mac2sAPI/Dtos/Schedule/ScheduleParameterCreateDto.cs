using System.ComponentModel.DataAnnotations;

namespace Mac2sAPI.Dtos.Schedule
{
    public class ScheduleParameterCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public TimeSpan Start { get; set; }
        [Required]
        public TimeSpan End { get; set; }
    }
}
