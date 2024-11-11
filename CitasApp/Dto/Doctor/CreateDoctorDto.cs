namespace CitasApp.Dto.Doctor
{
    public class CreateDoctorDto
    {
        public required string Specialty { get; set; }

        public required string LicenseNumber { get; set; }

        public required string Office { get; set; }

        public int UserId { get; set; }
    }
}
