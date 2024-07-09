using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ImageService
{
    public interface IImageService
    {
        Task<string> UploadImageWithStringAsync(string imagePath);

        Task<UploadResult> UploadImageAsync(IFormFile file);
    }
}
