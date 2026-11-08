namespace KASHOP.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public List<CategoryTranslations> Translations { get; set; } = new();
        public List<Product> Products { get; set; } = new();
    }
}
