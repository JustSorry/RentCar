using Microsoft.AspNetCore.Http;

namespace BAL.Services
{
    public static class FileService
    {
        public static async Task<string> Save(IFormFile img)
        {
            if (img == null)
            {
                return null;
            }
            string filePath = Path.Combine($"/Images/", img.FileName);
            using (var fileStream = new FileStream("wwwroot" + filePath, FileMode.Create))
            {
                await img.CopyToAsync(fileStream);
            }
            return filePath;
        }

        public static void Delete(string sourceFile)
        {
            if (File.Exists("wwwroot" + sourceFile))
                File.Delete("wwwroot" + sourceFile);
        }
    }
}
