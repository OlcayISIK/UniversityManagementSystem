using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Abstract.Shared;
using UMS.Business.Helpers;
using UMS.Dto;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.Shared
{
    public class FileOperations : IFileOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;
        public FileOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<bool>> UploadFiles(FileDto fileDto)
        {
            if (fileDto != null)
            {
                if (fileDto.DataFiles.Length > 0)
                {
                    ////Getting FileName
                    //var fileName = fileDto.Name;
                    ////Getting file Extension
                    //var fileExtension = Path.GetExtension(fileDto.FileType);
                    //// concatenating  FileName + FileExtension
                    //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    //var objfiles = new UMS.Data.Entities.UniversityBoundEntities.File()
                    //{
                    //    Id = 0,
                    //    UniversityId = _unitOfWork.UniversityId,
                    //    Name = newFileName,
                    //    FileType = fileExtension,
                    //    CreatedAt = DateTime.Now,
                    //    LastModifiedAt = DateTime.Now,
                    //};
                    var document = _mapper.Map<UMS.Data.Entities.UniversityBoundEntities.File>(fileDto);
                    document.UniversityId = _unitOfWork.UniversityId;

                    //using (var target = new MemoryStream())
                    //{
                    //    objfiles.DataFiles = fileDto.DataFiles;
                    //}

                    _unitOfWork.Files.Add(document);
                    await _unitOfWork.Commit();
                    return Result<bool>.CreateSuccessResult(true);

                }
            }
            return Result<bool>.CreateSuccessResult(false);
        }
    }
}
