using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Models
{
    public class Slot
    {
        [Key] public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsBooked { get; set; }

    }
}
