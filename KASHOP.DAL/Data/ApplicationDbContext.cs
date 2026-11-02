using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
 
namespace KASHOP.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<CategoryTranslations> CategoriesTranslations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
