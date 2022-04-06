using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace TestPostfix.DBModels
{
    public class DomainDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DefaultAliases { get; set; }
        public bool BackupMX { get; set; }
        public int MaxAlias { get; set; }
        public int MaxMailbox { get; set; }
        public List<AliasDB> Aliases { get; set; } = new();
        public List<MailboxDB> Mailboxes { get; set; } = new();
    }
}
