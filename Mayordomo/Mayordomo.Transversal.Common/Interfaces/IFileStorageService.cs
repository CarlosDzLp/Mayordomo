using Microsoft.AspNetCore.Http;

namespace Mayordomo.Transversal.Common.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file,string path);
        Task DeleteFileAsync(string fileName, string path);
        Task DeleteFileAsync(List<string> fileName, string path);
    }
}
