using CrudProjectWebAPI.Controllers.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public EmployeeSalaryController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("bysalary")]
        public IActionResult GetEmployeesBySalary()
        {
            var employees = _context.tblEmployee.OrderByDescending(e => e.EmployeeSalary).ToList();
            return Ok(employees);
        }
    }
}
