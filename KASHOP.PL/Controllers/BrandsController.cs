using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IGenericRepository<Brand> _repository;

        public BrandsController(IGenericRepository<Brand> repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var brands = _repository.Get();
            return Ok(brands);
        }

        [HttpPost("")]
        public IActionResult Create(Brand brand)
        {
            _repository.Create(brand);

            return Ok();
        }
    }
}
