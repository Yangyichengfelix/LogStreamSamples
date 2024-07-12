using System.ComponentModel.DataAnnotations;

namespace Mac2sAPI.Dtos.Gauge
{
    public class GaugeParameterDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [Range(-180, 179)]
        public int StartAngle { get; set; }
        [Range(-179, 180)]
        public int EndAngle { get; set; }
        [Range(1, 50)]

        public int step { get; set; }


        public int Breakpoint1 { get; set; }


        public int Breakpoint2 { get; set; }
    }
}
