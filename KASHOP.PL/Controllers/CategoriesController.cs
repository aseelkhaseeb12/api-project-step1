using KASHOP.BLL;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllAsync(cancellationToken);
            return Ok(categories);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryRequest request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.CreateAsync(request, cancellationToken);
            return result? Ok() : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id ,CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetByIdAsync(id,cancellationToken);
            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.DeleteAsync(id, cancellationToken);
            return result ? NoContent() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryRequest request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.UpdateAsync(id, request, cancellationToken);
            return result ? Ok() : BadRequest();
        }
    }
}