using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Abstract;
using UMS.Business.Helpers;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete
{
    internal class UniversityOperations : IUniversityOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;

        public UniversityOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Result<IEnumerable<UniversityDto>> GetAll()
        {
            var query = _unitOfWork.Universities.GetAll();
            var data = _mapper.ProjectTo<UniversityDto>(query);
            return Result<IEnumerable<UniversityDto>>.CreateSuccessResult(data);
        }
    }
}
