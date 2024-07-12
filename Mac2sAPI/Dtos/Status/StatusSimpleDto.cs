using Mac2sAPI.Dtos.StatusGroup;

namespace Mac2sAPI.Dtos.Status
{
    public class StatusSimpleDto : BaseDto
    {
        public string Name { get; set; }
        public int StatusGroupId { get; set; }
        public string StatusGroupName { get; set; }
        public string Color { get; set; }
        //public virtual StatusGroupDto StatusGroupDto { get; set; }
    }
}
