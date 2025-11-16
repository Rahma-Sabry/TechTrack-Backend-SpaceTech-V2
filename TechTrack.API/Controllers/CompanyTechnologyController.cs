using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.CompanyTechnology;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs;
using TechTrack.Infrastructure.Service;

namespace TechTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyTechnologyController : ControllerBase
    {
        private readonly ICompanyTechnologyService _service;

        public CompanyTechnologyController(ICompanyTechnologyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ct = await _service.GetByIdAsync(id);
            if (ct == null) return NotFound();
            return Ok(ct);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyTechnologyCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompanyTechnologyUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }
    }
}
