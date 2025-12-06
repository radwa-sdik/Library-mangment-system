namespace Library.Services
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile image, string folder = "books");
        Task<bool> DeleteImageAsync(string imageUrl);
    }

    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ImageUploadService> _logger;
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        private readonly long _maxFileSize = 5 * 1024 * 1024; // 5MB

        public ImageUploadService(IWebHostEnvironment environment, ILogger<ImageUploadService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<string> UploadImageAsync(IFormFile image, string folder = "books")
        {
            if (image == null || image.Length == 0)
                throw new ArgumentException("Invalid image file.");

            // Validate file extension
            var extension = Path.GetExtension(image.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
                throw new ArgumentException($"Only {string.Join(", ", _allowedExtensions)} files are allowed.");

            // Validate file size
            if (image.Length > _maxFileSize)
                throw new ArgumentException($"File size cannot exceed {_maxFileSize / (1024 * 1024)}MB.");

            // Create uploads directory if it doesn't exist
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", folder);
            Directory.CreateDirectory(uploadsFolder);

            // Generate unique filename
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Return relative URL
            return $"/uploads/{folder}/{uniqueFileName}";
        }

        public async Task<bool> DeleteImageAsync(string imageUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(imageUrl))
                    return false;

                var filePath = Path.Combine(_environment.WebRootPath, imageUrl.TrimStart('/'));
                
                if (File.Exists(filePath))
                {
                    await Task.Run(() => File.Delete(filePath));
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting image: {ImageUrl}", imageUrl);
                return false;
            }
        }
    }
}