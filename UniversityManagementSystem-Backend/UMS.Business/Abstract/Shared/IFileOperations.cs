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
        public Task<Result<bool>> UploadFiles(FileDto fileDto);
        public Result<IEnumerable<FileDto>> Get(long fileId);
        public Task<Result<IEnumerable<FileDto>>> GetAll(long studentId);
        public Task<Result<IEnumerable<FileDto>>> GetAllForTeacher(long teacherId);
    }
}
