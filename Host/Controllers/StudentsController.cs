using Application.Dtos;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService) => _studentService = studentService;

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new student and associated user account.")]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.CreateStudentAsync(dto);
            if (result.Data == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves all active students.")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentService.GetAllStudentsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves a student by their unique ID.")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _studentService.GetStudentByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates a student’s information.")]
        public async Task<IActionResult> Update(Guid id, [FromBody] StudentUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.UpdateStudentAsync(id, dto);
            if (result.Data == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Soft deletes a student by marking them inactive.")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            return Ok(result);
        }

        [HttpGet("search")]
        [SwaggerOperation(Summary = "Searches for students by name or email.")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var result = await _studentService.SearchStudentsAsync(keyword);
            return Ok(result);
        }
    }

}
