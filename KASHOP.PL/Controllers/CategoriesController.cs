using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoriesController(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var categories = _repository.Get();
            return Ok(categories);
        }

        [HttpPost("")]
        public IActionResult Create(Category category)
        {
            _repository.Create(category);

            return Ok();
        }
    }
}
