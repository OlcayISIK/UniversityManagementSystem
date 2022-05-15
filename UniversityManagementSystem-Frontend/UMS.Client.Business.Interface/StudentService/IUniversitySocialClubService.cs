using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Interface.StudentService
{
    public interface IUniversitySocialClubService
    {
        Task<Result<IEnumerable<UniversitySocialClubDto>>> GetAll();
        Task<Result<bool>> Join(long id);
    }
}
