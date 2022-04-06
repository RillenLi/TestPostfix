using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestPostfix.DBModels;

namespace TestPostfix.DBContext
{
    public interface IAdmContext
    {
        DbSet<DomainDB> Domains { get; set; }
        DbSet<AliasDB> Aliases { get; set; }
        DbSet<MailboxDB> Mailboxes { get; set; }
      
    }
}
