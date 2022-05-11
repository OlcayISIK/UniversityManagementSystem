using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.EF;
using UMS.Repository.Abstract;

namespace UMS.Repository.Shared
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public ITeacherRepository Teachers { get; set; }
        public IRedisTransactionsRepository RedisTransactions { get; set; }
        public IStudentRepository Students { get; set; }
        public IUniversitySocialClubRepository UniversitySocialClubs { get; set; }
        public IRedisTokenRepository RedisTokens { get; set; }
        public IChatMessageRepository ChatMessages { get; set; }
        public IUniversityRepository Universities { get; set; }
        public IFileRepository Files { get; set; }


        public UnitOfWork(Context context, ITeacherRepository teachers,IRedisTransactionsRepository redisTransactions, 
            IStudentRepository students, IUniversitySocialClubRepository universitySocialClubs, IRedisTokenRepository redisTokens, 
            IChatMessageRepository chatMessages, IUniversityRepository universities, IFileRepository files)
        {
            _context = context;
            Teachers = teachers;
            RedisTransactions = redisTransactions;
            Students = students;
            UniversitySocialClubs = universitySocialClubs;
            RedisTokens = redisTokens;
            ChatMessages = chatMessages;
            Universities = universities;
            Files  = files;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public long UniversityId => _context.UniversityId;
        public DateTime Now => _context.Now;

    }
}
