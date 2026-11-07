using KASHOP.BLL.Settings;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Mapster;
using System.Reflection.Metadata.Ecma335;

namespace KASHOP.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<List<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repository.GetAsync(
                includes: [c => c.Translations],
                cancellationToken: cancellationToken
            );
            return categories.Adapt<List<CategoryResponse>>();
        }

        public async Task<bool> CreateAsync(CategoryRequest request, CancellationToken cancellationToken = default)
        {
            if (!AreTranslationsValid(request.Translations)) return false;

            var names = request.Translations.Select(t => t.Name.ToLower()).ToList();

            var existing = await _repository.GetOneAsync(
                cancellationToken: cancellationToken,
                filter: c => c.Translations.Any(t => names.Contains(t.Name.ToLower()))
            );

            if (existing is not null) return false;

            var category = request.Adapt<Category>();
            await _repository.CreateAsync(category, cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await _repository.GetOneAsync(
                filter: c => c.Id == id,
                cancellationToken: cancellationToken
                );
            if (category is null) return false;
            await _repository.RemoveAsync(category, cancellationToken);
            return true;
        }

        public async Task<CategoryResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await _repository.GetOneAsync(
                filter: c => c.Id == id,
                includes: [c => c.Translations],
                cancellationToken: cancellationToken
                );
            return category.Adapt<CategoryResponse>();
        }

        public async Task<bool> UpdateAsync(int id, CategoryRequest request, CancellationToken cancellationToken = default)
        {
            if (!AreTranslationsValid(request.Translations)) return false;

            var existingCategory = await _repository.GetOneAsync(
                filter: c => c.Id == id,
                includes: [c => c.Translations],
                tracked: true,
                cancellationToken: cancellationToken
            );

            if (existingCategory is null) return false;

            var names = request.Translations.Select(t => t.Name.ToLower()).ToList();
            var duplicate = await _repository.GetOneAsync(
                cancellationToken: cancellationToken,
                filter: c => c.Id != id && c.Translations.Any(t => names.Contains(t.Name.ToLower()))
            );

            if (duplicate is not null) return false;

            existingCategory.Translations.Clear();
            foreach (var translationRequest in request.Translations)
            {
                existingCategory.Translations.Add(translationRequest.Adapt<CategoryTranslations>());
            }

            await _repository.UpdateAsync(existingCategory, cancellationToken);
            return true;
        }

        private static bool AreTranslationsValid(List<CategoryTranslationRequest> translations)
        {
            var languages = translations.Select(x => x.Language).ToList();

            if (languages.Distinct().Count() != languages.Count()) return false;

            return languages.Count == SupportedLanguages.Languages.Length &&
                SupportedLanguages.Languages.All(lang => languages.Contains(lang));
        }
    }
}
