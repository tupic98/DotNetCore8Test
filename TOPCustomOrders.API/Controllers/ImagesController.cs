using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TOPCustomOrders.API.Models.Domain;
using TOPCustomOrders.API.Models.DTO;
using TOPCustomOrders.API.Repositories;

namespace TOPCustomOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO imageRequestDto)
        {
            ValidateFileUpload(imageRequestDto);

            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = imageRequestDto.File,
                    FileDescription = imageRequestDto.FileDescription,
                    FileExtension = Path.GetExtension(imageRequestDto.FileName),
                    FileSizeInBytes = imageRequestDto.File.Length,
                    FileName = imageRequestDto.FileName
                };

                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }

            return BadRequest("Something went wrong");
        }

        private void ValidateFileUpload(ImageUploadRequestDTO imageRequestDTO)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(imageRequestDTO.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (imageRequestDTO.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size can't be more than 10MB. Please upload a smaller size file");
            }
        }
    }
}
