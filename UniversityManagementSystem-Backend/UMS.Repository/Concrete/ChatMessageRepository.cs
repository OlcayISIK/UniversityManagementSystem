using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.EF;
using UMS.Data.Entities;
using UMS.Repository.Abstract;
using UMS.Repository.Shared.GenericRepositories;

namespace UMS.Repository.Concrete
{
    internal class ChatMessageRepository : Repository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(Context context) : base(context)
        {
        }
        public void IdentityInsertOn()
        {
            Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Students ON;");
        }
        public void IdentityInsertOff()
        {
            Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Students OFF;");
        }

    }
}
