using Application.Interfaces.External;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class UploadService : IUploadService
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            string path = @"C:\Users\User\Desktop\Images";
            if(!Directory.Exists(path)) Directory.CreateDirectory(path);
            string fileName = $"{Guid.NewGuid().ToString()}{file.FileName}.jpg";
            string filePath = Path.Combine(path, fileName);

            using(var str = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(str);
            }

            return filePath;
        }
    }
}
