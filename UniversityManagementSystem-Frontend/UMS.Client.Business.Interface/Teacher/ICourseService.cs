using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Interface.Teacher
{
    public interface ICourseService
    {
        Task<Result<IEnumerable<CourseDto>>> GetAll(long courseInstructorId);
    }
}
