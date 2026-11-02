using KASHOP.DAL.DTO.Requests;

namespace KASHOP.DAL.DTO.Responses
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public List<CategoryTranslationRequest> Translations { get; set; } = new();
        public bool Status { get; set; }
    }
}
