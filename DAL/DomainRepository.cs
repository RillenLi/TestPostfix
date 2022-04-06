using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestPostfix.Models;
using TestPostfix.DB;
using TestPostfix.DBModels;
using TestPostfix.DBContext;

namespace TestPostfix.DAL
{
    public class DomainRepository : IDomainRepository
    {
        private readonly AdmContext _context;
        public DomainRepository(AdmContext context)
        {
            _context = context;
        }
        public IEnumerable<Domain> DomainList()
        {
            return _context.Domains.Include(d => d.Aliases).Include(d => d.Mailboxes).Select(d => new Domain(d));
        }
        public string DomainAdded(Domain domain)
        {
            if (domain != null)
            {
                DomainDB domainDB = new DomainDB()
                {
                    Name = domain.Name,
                    Description = domain.Description,
                    DefaultAliases = domain.DefaultAliases,
                    BackupMX = domain.BackupMX,
                    MaxAlias = domain.MaxAlias,
                    MaxMailbox = domain.MaxMailbox
                };
                _context.Add(domainDB);
                _context.SaveChanges();
                return "Success";
            }
            else return "Error";
        }
        public Domain DomainGet(int id)
        {
            var res = _context.Domains.Include(d => d.Aliases).Include(d => d.Mailboxes).FirstOrDefault(d => d.Id == id);
            if (res != null)
            {
                Domain domain = new Domain(res);
                return domain;
            }
            else return new Domain("Error");
        }
        public string DomainEdit(Domain domain)
        {
            if (domain != null)
            {
                var domainDB = _context.Domains.FirstOrDefault(d => d.Id == domain.Id);
                domainDB.Id = domain.Id;
                domainDB.Name = domain.Name;
                domainDB.DefaultAliases = domain.DefaultAliases;
                domainDB.MaxAlias = domain.MaxAlias;
                domainDB.MaxMailbox = domain.MaxMailbox;
                domainDB.BackupMX = domain.BackupMX;
                domainDB.Description = domain.Description;
                _context.Domains.Update(domainDB);
                _context.SaveChanges();
                return "Success";
            }
            else return "ERROR";
        }
        public string DomainDel(int id)
        {
            DomainDB domainDB = _context.Domains.FirstOrDefault(d => d.Id == id);
            if (domainDB != null)
            {
                _context.Domains.Remove(domainDB);
                _context.SaveChanges();
                return "Success";
            }
            else return "Error";
        }
    }
}
