using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;
using UMS.Client.Dtos.Teacher;

namespace UMS.Client.Business.Interface.Teacher
{
    public interface ITeacherService
    {
        Task<Result<IEnumerable<CourseInstructorDto>>> GetAll();
        Task<Result<CourseInstructorDto>> Get(long userId);
    }
}
