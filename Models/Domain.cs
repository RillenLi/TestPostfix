using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TestPostfix.DBModels;

namespace TestPostfix.Models
{
    public class Domain
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Domain name not specified")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DefaultAliases { get; set; } = true;
        public bool BackupMX { get; set; } = false;
        [Range(-1, 100, ErrorMessage = "MaxAlias not in the specified range")]
        public int MaxAlias { get; set; }
        [Range(-1, 100, ErrorMessage = "MaxMailbox not in the specified range")]
        public int MaxMailbox { get; set; }
        public IEnumerable<Alias> Aliases { get; set; } 
        public IEnumerable<Mailbox> Mailboxes { get; set; }
        public string DError { get; set; }
        public Domain() { }
        public Domain(string e)
        {
            DError = e;
        }
        public Domain(DomainDB domainDB)
        {
            Id = domainDB.Id;
            Name = domainDB.Name;
            Description = domainDB.Description;
            DefaultAliases = domainDB.DefaultAliases;
            BackupMX = domainDB.BackupMX;
            MaxAlias = domainDB.MaxAlias;
            MaxMailbox = domainDB.MaxMailbox;
            Aliases = domainDB.Aliases.Select(a=>new Alias(a));
            Mailboxes = domainDB.Mailboxes.Select(m => new Mailbox(m));
        }
    }
}
