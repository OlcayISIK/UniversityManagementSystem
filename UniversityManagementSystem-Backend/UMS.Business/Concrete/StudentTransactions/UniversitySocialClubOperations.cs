using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Helpers;
using UMS.Dto;
using UMS.Repository.Shared;

namespace UMS.Business.Abstract.StudentTransactions
{
    public class UniversitySocialClubOperations : IUniversitySocialClubOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;

        public UniversitySocialClubOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<IEnumerable<UniversitySocialClubDto>> GetAll()
        {
            var query = _unitOfWork.UniversitySocialClubs.GetAll();
            var data =  _mapper.ProjectTo<UniversitySocialClubDto>(query);
            return Result<IEnumerable<UniversitySocialClubDto>>.CreateSuccessResult(data);
        }
    }
}
