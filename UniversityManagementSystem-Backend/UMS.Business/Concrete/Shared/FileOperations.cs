using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Abstract.Shared;
using UMS.Dto;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.Shared
{
    public class FileOperations : IFileOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public FileOperations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> UploadFiles(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var objfiles = new UMS.Data.Entities.UniversityBoundEntities.File()
                    {
                        Id = 0,
                        UniversityId = _unitOfWork.UniversityId,
                        Name = newFileName,
                        FileType = fileExtension,
                        CreatedAt = DateTime.Now,
                        LastModifiedAt = DateTime.Now,
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFiles = target.ToArray();
                    }

                    _unitOfWork.Files.Add(objfiles);
                    await _unitOfWork.Commit();
                    return Result<bool>.CreateSuccessResult(true);

                }
            }
            return Result<bool>.CreateSuccessResult(false);
        }
    }
}
