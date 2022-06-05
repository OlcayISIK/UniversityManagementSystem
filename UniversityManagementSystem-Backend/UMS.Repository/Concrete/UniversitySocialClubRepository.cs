using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMS.Data.EF;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Repository.Abstract;
using UMS.Repository.Shared.GenericRepositories;

namespace UMS.Repository.Concrete
{
    internal class UniversitySocialClubRepository : UniversityBoundRepository<UniversitySocialClub>, IUniversitySocialClubRepository
    {
        public UniversitySocialClubRepository(Context context) : base(context)
        {
        }
        public IQueryable<UniversitySocialClub> GetParticipantsOfSocialClub()
        {
            //return Context.Set<UniversitySocialClub>().Where(c => c.Id == cat_id).SelectMany(c => Articles);
            IQueryable <UniversitySocialClub> query = Context.UniversitySocialClubs
                .Include(club => club.StudentsUniversitySocialClubs)
                .ThenInclude(student => student.Student);
            return query;
        }
       

    }
}
