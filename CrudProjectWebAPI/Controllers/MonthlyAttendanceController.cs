using CrudProjectWebAPI.Controllers.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyAttendanceController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public MonthlyAttendanceController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("absent")]
        public IActionResult GetMonthlyAttendanceReport()
        {
         var report = _context.tblEmployeeAttendance
         .Join(_context.tblEmployee,
         attendance => attendance.EmployeeId,
         employee => employee.EmployeeId,
         (attendance, employee) => new
        {
            employee.EmployeeName,
            attendance.AttendanceDate,
            attendance.IsPresent,
            attendance.IsAbsent,
            attendance.IsOffday
        })
         .AsEnumerable() // Perform client-side evaluation from this point
         .GroupBy(x => new
    {
         x.EmployeeName,
         MonthName = x.AttendanceDate.ToString("MMMM")
    })
         .Select(g => new
     {
         g.Key.EmployeeName,
         g.Key.MonthName,
         TotalPresent = g.Sum(x => x.IsPresent ? 1 : 0),
         TotalAbsent = g.Sum(x => x.IsAbsent ? 1 : 0),
         TotalOffday = g.Sum(x => x.IsOffday ? 1 : 0)
     })
    .ToList();



            return Ok(report);
        }
    }
}
