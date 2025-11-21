using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Models
{
    public class Doctor
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
    }
}
