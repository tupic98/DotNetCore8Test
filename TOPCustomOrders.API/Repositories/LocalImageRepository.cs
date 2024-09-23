using TOPCustomOrders.API.Data;
using TOPCustomOrders.API.Models.Domain;

namespace TOPCustomOrders.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webhostEnv;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _dbContext;

        public LocalImageRepository(IWebHostEnvironment webhostEnv, IHttpContextAccessor httpContextAccessor, AppDbContext dbContext)
        {
            _webhostEnv = webhostEnv;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(_webhostEnv.ContentRootPath, "Images", image.FileName, image.FileExtension);

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;

            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return image;
        }
    }
}
