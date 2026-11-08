using Microsoft.AspNetCore.Http;

namespace KASHOP.BLL
{
    public class FileService : IFileService
    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".png", ".webp" };
        private const long MaxFileSize = 2 * 1024 * 1024;// 2MB
        private static readonly string ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        public async Task<string?> UploadAsync(IFormFile file, CancellationToken cancellationToken)
        {
            if (file is null || file.Length == 0 || file.Length > MaxFileSize) return null;
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (!AllowedExtensions.Contains(extension)) return null;
            var fileName = Guid.NewGuid().ToString() + extension;//dgwufidgbakjd.jpg
            Directory.CreateDirectory(ImagesPath);
            var filePath = Path.Combine(ImagesPath, fileName);
            await using var stream = File.Create(filePath);
            await file.CopyToAsync(stream, cancellationToken);
            return fileName;
        }

        public void Delete(string fileName)
        {
            var filePath = Path.Combine(ImagesPath, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
