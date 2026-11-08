using Microsoft.AspNetCore.Http;

namespace KASHOP.BLL
{
    public interface IFileService
    {
        Task<string?> UploadAsync(IFormFile file, CancellationToken cancellationToken);
        void Delete(string fileName);
    }
}
