using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.InterviewQuestion;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs;

namespace TechTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewQuestionController : ControllerBase
    {
        private readonly IInterviewQuestionService _service;

        public InterviewQuestionController(IInterviewQuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InterviewQuestionCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InterviewQuestionUpdateDto dto)
        {
            return Ok(await _service.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}
