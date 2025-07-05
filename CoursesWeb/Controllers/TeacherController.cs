using Microsoft.AspNetCore.Mvc;
using CoursesWeb.DTOs.Request.Teacher;
using CoursesWeb.DTOs.Response;
using CoursesWeb.Services.Contracts;
using CoursesWeb.DTOs.Request.TeacherEntity;

namespace CoursesWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: api/teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherMiniResponseDTO>>> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }

        // GET: api/teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherMiniResponseDTO>> GetById(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            return Ok(teacher);
        }

        // POST: api/teachers
        [HttpPost]
        public async Task<ActionResult<TeacherMiniResponseDTO>> Create([FromBody] TeacherCreateReqDTO dto, CancellationToken cancellationToken)
        {
            var createdTeacher = await _teacherService.CreateAsync(dto, cancellationToken);
            // Повертаємо 201 Created + лінк на новий ресурс
            return CreatedAtAction(nameof(GetById), new { id = createdTeacher.Id }, createdTeacher);
        }

        // PUT: api/teachers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherMiniResponseDTO>> Update(int id, [FromBody] TeacherUpdateReqDTO dto, CancellationToken cancellationToken)
        {
            var updatedTeacher = await _teacherService.UpdateAsync(id, dto, cancellationToken);
            return Ok(updatedTeacher);
        }

        // DELETE: api/teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _teacherService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
