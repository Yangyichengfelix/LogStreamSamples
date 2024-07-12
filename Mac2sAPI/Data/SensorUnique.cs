using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Data
{
    [Keyless]
    public class SensorUnique
    {
        public DateTime Date_Heure { get; set; }
        public double? Value { get; set; }
        public float? High { get; set; }
        public float? Low { get; set; }
        public string? Nr_Moule { get; set; }

    }
}
