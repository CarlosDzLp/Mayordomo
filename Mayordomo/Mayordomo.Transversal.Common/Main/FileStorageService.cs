using Mayordomo.Transversal.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Mayordomo.Transversal.Common.Main
{
    public class FileStorageService : IFileStorageService
    {
        public async Task DeleteFileAsync(string fileName, string path)
        {
            if (string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(path))
                return;
            var fullPath = Path.Combine(path, fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public async Task DeleteFileAsync(List<string> fileName, string path)
        {
            if(fileName == null || fileName.Count == 0 || string.IsNullOrWhiteSpace(path))
                return;
            foreach (var file in fileName)
            {
                var fullPath = Path.Combine(path, file);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file, string path)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
