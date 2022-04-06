using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestPostfix.Models;
using TestPostfix.DBModels;
using TestPostfix.DB;

namespace TestPostfix.DAL
{
    public class AliasRepository : IAliasRepository
    {
        private readonly AdmContext _context;
        public AliasRepository(AdmContext context)
        {
            _context = context;
        }
        public IEnumerable<Alias> AliasList()
        {
            return _context.Aliases.Include(d => d.DomainDB).Select(a => new Alias(a));
        }
        public string AddAlias(Alias alias)
        {
            if (alias != null)
            {
                int acount = _context.Aliases.Count(a => a.DomainDBId == alias.DomainId);
                var d = _context.Domains.FirstOrDefault(d => d.Id == alias.DomainId);
                if (d.MaxAlias==0||(acount < d.MaxAlias&& d.MaxAlias!=-1))
                {
                    AliasDB aliasDB = new AliasDB()
                    {
                        Id = alias.Id,
                        Name = alias.Name,
                        DomainDBId = alias.DomainId,
                        Active = alias.Active,
                        MailToSent = alias.MailToSent
                    };
                    _context.Aliases.Add(aliasDB);
                    _context.SaveChanges();
                    return "Success";
                }
                else return "Max alias in domen";
            }
            else return "Error";
        }
        public Alias GetAlias(int id)
        {
            var al = _context.Aliases.Include(d => d.DomainDB).FirstOrDefault(a => a.Id == id);
            if (al != null)
            {
                return new Alias(al);
            }
            else return new Alias("Error");
        }
        public string EditAlias(Alias alias)
        {
            if (alias != null)
            {
                int acount = _context.Aliases.Count(a => a.DomainDBId == alias.DomainId);
                var d = _context.Domains.FirstOrDefault(d => d.Id == alias.DomainId);
                if (acount < d.MaxAlias && d.MaxAlias!=-1)
                {
                    var aliasDB = _context.Aliases.FirstOrDefault(a => a.Id == alias.Id);
                    aliasDB.Id = alias.Id;
                    aliasDB.Name = alias.Name;
                    aliasDB.DomainDBId = alias.DomainId;
                    aliasDB.Active = alias.Active;
                    aliasDB.MailToSent = alias.MailToSent;
                    _context.Aliases.Update(aliasDB);
                    _context.SaveChanges();
                    return "Success";
                }
                else return "Maximum aliases";
            }
            else return "Error";
        }
        public string DelAlias(int id)
        {
            var al = _context.Aliases.FirstOrDefault(a => id == a.Id);
            if (al != null)
            {
                _context.Aliases.Remove(al);
                _context.SaveChanges();
                return "Succsess";
            }
            else return "Error";
        }
    }
}
