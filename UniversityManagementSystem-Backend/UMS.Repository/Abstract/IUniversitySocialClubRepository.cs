using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Repository.Shared.GenericRepositories;

namespace UMS.Repository.Abstract
{
    public interface IUniversitySocialClubRepository : IRepository<UniversitySocialClub>
    {
        IQueryable<UniversitySocialClub> GetParticipantsOfSocialClub();
    }
}
