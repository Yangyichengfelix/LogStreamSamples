using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Data
{
    [Keyless]

    public class SensorPl
    {
        public DateTime Date_Heure { get; set; }
        public double? Value { get; set; }
    }
}
