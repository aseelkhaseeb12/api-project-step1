using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        [HttpGet("")]
        public IActionResult Index()
        {
            var categories = repo.Get();
            return Ok(categories);
        }

        [HttpPost("")]
        public IActionResult Create(Category category)
        {
            repo.Create(category);

            return Ok();
        }
    }
}
