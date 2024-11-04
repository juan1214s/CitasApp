using CitasApp.Entityes.Doctor;

namespace CitasApp.Entityes.SheduleProgramming
{
    //aca se van a guardar los horarios de las citas
    public class ScheduleProgrammingEntity
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan FinalHour { get; set; }

        public bool State { get; set; }

        public int DoctorId { get; set; }

        public DoctorEntity Doctor { get; set; }
    }
}
