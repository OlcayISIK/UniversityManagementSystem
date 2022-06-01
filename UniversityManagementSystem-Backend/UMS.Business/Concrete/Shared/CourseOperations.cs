using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Abstract.Shared;
using UMS.Business.Helpers;
using UMS.Dto;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.Shared
{
    public class CourseOperations : ICourseOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;

        public CourseOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Result<IEnumerable<CourseDto>> GetAll(long courseInstructorId)
        {
            var query = _unitOfWork.Courses.GetAll().Where(x => x.CourseInstructorId == courseInstructorId);
            var data = _mapper.ProjectTo<CourseDto>(query);
            return Result<IEnumerable<CourseDto>>.CreateSuccessResult(data);
        }
    }
}
