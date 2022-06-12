using UMS.Client.Dtos;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Interface.Shared
{
    public interface IFileService
    {
        Task<Result<bool>> UploadFiles(FileDto fileDto);
        Task<Result<IEnumerable<FileDto>>> Get(long fileId);
        public Task<Result<IEnumerable<FileDto>>> GetAll(long studentId);
        public Task<Result<IEnumerable<FileDto>>> GetAllForTeacher(long studentId);
    }
}
