using Mac2sAPI.Dtos.LogDuration;
using Mac2sAPI.Dtos.StatusGroup;
using System.Collections.Generic;

namespace Mac2sAPI.Dtos.Status
{
    public class StatusDto : BaseDto
    {
        public string Name { get; set; }
        public int StatusGroupId { get; set; }
        public string StatusGroupName { get; set; }
        public virtual  IList<LogDurationDto> LogDurations { get; set; }

        public virtual StatusGroupDto StatusGroupDto { get; set; }
    }
}
