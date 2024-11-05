namespace CitasApp.Dto.ScheduleDto
{
    public class ScheduleProgrammingDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public bool State { get; set; }

        public int DoctorId { get; set; }
    }
}
