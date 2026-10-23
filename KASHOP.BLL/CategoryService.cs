using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Mapster;

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
            var categories = await _repository.GetAsync(cancellationToken: cancellationToken);
            return categories.Adapt<List<CategoryResponse>>();
        }

        public async Task<bool> CreateAsync(CategoryRequest request, CancellationToken cancellationToken = default)
        {
            var exists = await _repository.GetOneAsync(
                cancellationToken: cancellationToken,
                filter: c => c.Name.ToLower() == request.Name.ToLower()
            );

            if (exists is not null) return false;

            var category = request.Adapt<Category>();
            await _repository.CreateAsync(category, cancellationToken);
            return true;
        }

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int id, CategoryRequest request, CancellationToken cancellationToken = default)
        {
            var category = request.Adapt<Category>();
            await _repository.UpdateAsync(category, cancellationToken);
            return true;
        }
    }
}
