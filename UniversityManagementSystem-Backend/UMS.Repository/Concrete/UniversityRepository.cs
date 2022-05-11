using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.EF;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Repository.Abstract;
using UMS.Repository.Shared.GenericRepositories;

namespace UMS.Repository.Concrete
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(Context context) : base(context)
        {
        }
    }
}
