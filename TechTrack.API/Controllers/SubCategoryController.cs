using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.SubCategory;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs.SubCategory;

namespace TechTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _service;

        public SubCategoryController(ISubCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryCreateDto dto) =>
            Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubCategoryUpdateDto dto) =>
            Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await _service.DeleteAsync(id));
    }
}
