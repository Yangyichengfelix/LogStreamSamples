namespace Blazor_mac2c.Models
{
    public class ScheduleParameterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
