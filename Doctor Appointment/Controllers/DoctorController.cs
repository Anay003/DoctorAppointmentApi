using Doctor_Appointment.Context;
using Doctor_Appointment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctor_Appointment.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly AppDbContext _db;
        public DoctorController(AppDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Doctor")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _db.Doctors.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while listing Doctors.", detail = ex.Message });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, Doctor")]
        public async Task<IActionResult> DoctorRegistration(Doctor doctor)
        {
            try
            {
                _db.Doctors.Add(doctor);
                await _db.SaveChangesAsync();
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = "An error occured while registrating Doctor", detail=ex.Message });
            }

 
        }
    }
}
