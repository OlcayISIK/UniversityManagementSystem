using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto;
using UMS.Dto.Student;

namespace UMS.Business.Abstract.StudentTransactions
{
    public interface IUniversitySocialClubOperations
    {
        Result<IEnumerable<UniversitySocialClubDto>> GetAll();
        Task<Result<bool>> Join(StudentsUniversitySocialClubDto studentsUniversitySocialClubDto);

    }
}
