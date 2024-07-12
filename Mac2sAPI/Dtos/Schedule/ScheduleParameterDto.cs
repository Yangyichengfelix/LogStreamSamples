namespace Mac2sAPI.Dtos.Schedule
{
    public class ScheduleParameterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
         
    }
}
