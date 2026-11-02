namespace KASHOP.DAL.Models
{
    public class CategoryTranslations
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Language { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
