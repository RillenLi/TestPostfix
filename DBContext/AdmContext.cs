using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TestPostfix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using TestPostfix.DBModels;
using TestPostfix.DBContext;

namespace TestPostfix.DB
{
    public class AdmContext : DbContext, IAdmContext
    {
        public DbSet<DomainDB> Domains { get; set; }
        public DbSet<AliasDB> Aliases { get; set; }
        public DbSet<MailboxDB> Mailboxes { get; set; }
        public AdmContext(DbContextOptions<AdmContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
