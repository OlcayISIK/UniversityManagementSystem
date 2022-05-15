using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto;

namespace UMS.Business.Abstract.Shared
{
    public interface IUniversityOperations
    {
        Result<IEnumerable<UniversityDto>> GetAll();
    }
}
