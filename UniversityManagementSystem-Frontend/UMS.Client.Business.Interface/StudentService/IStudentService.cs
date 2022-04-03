using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Business.Interface.StudentService
{
    public interface IStudentService
    {
        Task<Result<IEnumerable<StudentDto>>> GetAll();
        Task<Result<StudentDto>> Get(long userId);
    }
}
