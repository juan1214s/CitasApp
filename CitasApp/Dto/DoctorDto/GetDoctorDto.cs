namespace CitasApp.Dto.Doctor
{
    public class GetDoctorDto
    {
        public int Id { get; set; }

        public string Specialty { get; set; }

        public string LicenseNumber { get; set; }

        public required string Office { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }
 
        public int LocationId { get; set; }

        public string Location { get; set; }
    }
}
