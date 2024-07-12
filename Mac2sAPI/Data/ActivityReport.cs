using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mac2sAPI.Data
{
    [Keyless]
   // [NotMapped]
    public class ActivityReport
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public int Grp { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Color { get; set; }
    }
}
