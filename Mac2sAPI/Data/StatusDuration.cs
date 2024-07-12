using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Data
{
    [Keyless]

    public class StatusDuration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  Duration { get; set; }
        public string Color { get; set; }
    }
}
