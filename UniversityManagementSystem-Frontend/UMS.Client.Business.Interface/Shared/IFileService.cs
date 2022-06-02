using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Interface.Shared
{
    public interface IFileService
    {
        Task<Result<bool>> Uploadfile(FileDto fileDto);
        Task<Result<IEnumerable<FileDto>>> GetAll();
    }
}
