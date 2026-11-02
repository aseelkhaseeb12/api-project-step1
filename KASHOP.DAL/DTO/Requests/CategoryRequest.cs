using Microsoft.Extensions.Logging;

namespace KASHOP.DAL.DTO.Requests
{
    public class CategoryRequest
    {
        public bool Status { get; set; }
        public List<CategoryTranslationRequest> Translations { get; set; } = new();
    }
}
