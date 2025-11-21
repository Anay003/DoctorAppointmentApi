using Doctor_Appointment.Context;
using Doctor_Appointment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctor_Appointment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlotsController : Controller
    {
        private readonly AppDbContext _db;
        public SlotsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("{doctorId}")]
        [Authorize (Roles ="Admin, Doctor")]
        public async Task<IActionResult> GetByDoctor(int doctorId)
        {
            try
            {
                var slots = await _db.Slots
                        .Where(s => s.DoctorId == doctorId)
                        .ToListAsync();

                return Ok(slots);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while listing slots.", detail = ex.Message });
            }
        }

        [HttpPost("AddSlot")]
        public async Task<IActionResult> AddSlot(Slot slot)
        {
            try
            {
                _db.Slots.Add(slot);
                await _db.SaveChangesAsync();
                return Ok(slot);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while adding slot.", detail = ex.Message });
            }
        }
    }
}
