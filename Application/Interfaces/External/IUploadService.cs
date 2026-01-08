using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.External
{
    public interface IUploadService
    {
        Task<string> UploadImage(IFormFile file);
    }
}
