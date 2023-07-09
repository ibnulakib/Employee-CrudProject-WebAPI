using CrudProjectWebAPI.Controllers.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAbsentController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public EmployeeAbsentController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("absent")]
        public IActionResult GetEmployeesWithAbsentDays()
        {
            var employeeIds = _context.tblEmployeeAttendance
                .Where(a => a.IsAbsent)
                .Select(a => a.EmployeeId)
                .Distinct()
                .ToList();

            var employees = _context.tblEmployee.Where(e => employeeIds.Contains(e.EmployeeId)).ToList();

            return Ok(employees);
            //return Ok("1");
        }
    }
}
