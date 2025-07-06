using CoursesWeb.BLL.DTOs.Response;
using CoursesWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CoursesWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        [HttpGet("{id}")]
        public async Task <ActionResult<IEnumerable<AttendanceWithStudentResponseDTO>>> GetAll(int id)
        {
            var attendaces = await attendanceService.GetByStudentIdAsync(id);
            return Ok(attendaces);
        }
    }
}
