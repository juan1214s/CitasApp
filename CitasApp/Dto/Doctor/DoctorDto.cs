namespace CitasApp.Dto.Doctor
{
    public class DoctorDto
    {
        public int Id { get; set; }

        public required string Specialty { get; set; }

        public required string LicenseNumber { get; set; }

        public required string Office { get; set; }

        public int UserId { get; set; }
    }
}
