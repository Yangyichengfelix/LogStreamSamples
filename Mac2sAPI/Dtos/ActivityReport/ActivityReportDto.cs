using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mac2sAPI.Dtos.ActivityReport
{
    public class ActivityReportDto
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public int Grp { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Color { get; set; }
    }
}
