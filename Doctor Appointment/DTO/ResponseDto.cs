namespace Doctor_Appointment.DTO
{
    public class ResponseDto
    {
        public string Token { get; set; } = null!;
        public int UserId { get; set; }
        public string Role { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
