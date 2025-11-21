using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Models
{
    public class Appointment
    {
        [Key] public int Id { get; set; }
        public int SlotId { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; } = "Booked";
    }
}
