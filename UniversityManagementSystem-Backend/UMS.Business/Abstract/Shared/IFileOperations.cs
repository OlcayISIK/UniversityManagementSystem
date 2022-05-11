using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UMS.Dto;

namespace UMS.Business.Abstract.Shared
{
    public interface IFileOperations
    {
        public Task<Result<bool>> UploadFiles(IFormFile files);
    }
}
