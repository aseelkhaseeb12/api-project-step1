using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet("")]
        public IActionResult Index()
        {
            var brands = context.Brands.Where(b => b.Status == true).AsNoTracking().ToList();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var brand = context.Brands.Find(id);
            return Ok(brand);
        }

        [HttpPost("")]
        public IActionResult Create(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();

            return Ok();
        }
    }
}
