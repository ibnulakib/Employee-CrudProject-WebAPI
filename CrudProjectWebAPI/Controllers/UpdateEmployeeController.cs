using CrudProjectWebAPI.Controllers.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateEmployeeController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public UpdateEmployeeController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}/employeecode")]
        public IActionResult UpdateEmployeeCode(int id, [FromBody] string newEmployeeCode)
        {
            var employee = _context.tblEmployee.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            // Check if the new employee code already exists
            var existingEmployee = _context.tblEmployee.FirstOrDefault(e => e.EmployeeCode == newEmployeeCode);
            if (existingEmployee != null)
            {
                return BadRequest("Employee code already exists.");
            }

            employee.EmployeeCode = newEmployeeCode;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
