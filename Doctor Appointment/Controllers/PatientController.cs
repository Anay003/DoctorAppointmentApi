using Doctor_Appointment.Context;
using Doctor_Appointment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctor_Appointment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {
        private readonly AppDbContext _db;
        public PatientsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Authorize(Roles = "Doctor, Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _db.Patients.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while listing Patients.", detail = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Patient patient)
        {
            try
            {
                _db.Patients.Add(patient);
                await _db.SaveChangesAsync();
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while registring Patients.", detail = ex.Message });

            }
        }
    }
}
