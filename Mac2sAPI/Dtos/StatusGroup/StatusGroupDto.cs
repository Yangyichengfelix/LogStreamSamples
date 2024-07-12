using Mac2sAPI.Dtos.Status;

namespace Mac2sAPI.Dtos.StatusGroup
{
    public class StatusGroupDto : BaseDto
    {
        public string Name { get; set; }
        public virtual List<StatusDto> Status { get; set; }
        public string Color { get; set; }
    }
}
