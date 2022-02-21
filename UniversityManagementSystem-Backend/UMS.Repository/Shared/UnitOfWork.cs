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

        public UnitOfWork(Context context, ITeacherRepository teachers)
        {
            _context = context;
            Teachers = teachers;
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
