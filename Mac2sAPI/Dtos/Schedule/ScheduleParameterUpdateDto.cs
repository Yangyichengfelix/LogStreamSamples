using System.ComponentModel.DataAnnotations;

namespace Mac2sAPI.Dtos.Schedule
{
    public class ScheduleParameterUpdateDto: ScheduleParameterCreateDto
    {
        [Required]
        public int Id { get; set; }

    }
}
