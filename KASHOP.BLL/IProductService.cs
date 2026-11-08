using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;

namespace KASHOP.BLL
{
    public interface IProductService
    {
        Task<bool> CreateAsync(ProductRequest request, CancellationToken cancellationToken = default);
        Task<List<ProductResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
