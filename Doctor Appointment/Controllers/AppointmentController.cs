using Doctor_Appointment.Context;
using Doctor_Appointment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_Appointment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext _db;
        public AppointmentsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("book")]
        [Authorize(Roles ="Admin, Patient")]
        public async Task<IActionResult> Book(Appointment appointment)
        {
            var slot = await _db.Slots.FindAsync(appointment.SlotId);
            if (slot == null || slot.IsBooked)
            { 
                return BadRequest("Slot unavailable"); 
            }
            try
            {
                slot.IsBooked = true;
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return Ok(appointment);
            }
            catch (Exception ex) { 
                return BadRequest(new { Message = "Error in making appointment", details = ex.Message });
            }
        }
    }
}
