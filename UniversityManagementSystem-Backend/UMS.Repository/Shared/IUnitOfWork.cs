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
        IStudentRepository Students { get; }
    }
}
