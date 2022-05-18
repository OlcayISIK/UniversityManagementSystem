using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Interface.Shared
{
    public interface IUniversityService
    {
        Task<Result<IEnumerable<UniversityDto>>> GetAll();
    }
}
