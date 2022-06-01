using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Repository.Abstract;

namespace UMS.Repository.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        DateTime Now { get; }
        long UniversityId { get; }
        Task<int> Commit();

        ITeacherRepository Teachers { get; }
        IRedisTransactionsRepository RedisTransactions { get; }
        IRedisTokenRepository RedisTokens { get; }
        IStudentRepository Students { get; }
        IUniversitySocialClubRepository UniversitySocialClubs { get; }
        IChatMessageRepository ChatMessages { get; }
        IUniversityRepository Universities{ get; }
        IFileRepository Files { get; }
        IEventRepository Events { get; }
        ICourseRepository Courses { get; }
        IStudentGradeRepository StudentGrades { get; }
    }
}
