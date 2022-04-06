using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPostfix.Models;
using TestPostfix.DB;
using TestPostfix.DBModels;
using Microsoft.EntityFrameworkCore;

namespace TestPostfix.DAL
{
    public class MailRepository:IMailRepository
    {
        private AdmContext _context;
        public MailRepository(AdmContext context)
        {
            _context = context;
        }
        public IEnumerable<Mailbox> ListMailbox()
        {
            var mlist = _context.Mailboxes.Include(d => d.DomainDB).Select(m => new Mailbox(m));
            return mlist;
        }
        public string AddMail(Mailbox mailbox)
        {
            if (mailbox != null)
            {
                int mcount = _context.Mailboxes.Count(m => m.DomainDBId == mailbox.DomainId);
                var d = _context.Domains.FirstOrDefault(d => d.Id == mailbox.DomainId);
                if (d.MaxMailbox == 0 || mcount < d.MaxMailbox && d.MaxMailbox != -1)
                {
                    MailboxDB mdb = new MailboxDB()
                    {
                        Id = mailbox.Id,
                        Name = mailbox.Name,
                        Password = mailbox.Password,
                        WelkomeMail = mailbox.WelkomeMail,
                        Username = mailbox.Username,
                        DomainDBId = mailbox.DomainId,
                        Active = mailbox.Active
                    };
                    _context.Mailboxes.Add(mdb);
                    _context.SaveChanges();
                    return "Success";
                }
                else return "No many mailbox in domain";
            }
            else return "Error";
        }
        public Mailbox GetMailbox(int id)
        {
            MailboxDB m = _context.Mailboxes.Include(m=>m.DomainDB).FirstOrDefault(m => m.Id == id);
            if (m != null)
            {
                Mailbox ret = new Mailbox(m);
                return ret;
            }
            else return new Mailbox("Error");
        }
        public string EditMail(Mailbox mailbox)
        {
            if (mailbox!= null)
            {
                int mcount = _context.Mailboxes.Count(m => m.DomainDBId == mailbox.DomainId);
                var d = _context.Domains.FirstOrDefault(d => d.Id == mailbox.DomainId);
                if (d.MaxMailbox == 0 || mcount < d.MaxMailbox && d.MaxMailbox != -1)
                {
                    MailboxDB mdb = new MailboxDB
                    {
                        Id = mailbox.Id,
                        Name = mailbox.Name,
                        Username = mailbox.Username,
                        DomainDBId = mailbox.DomainId,
                        Password = mailbox.Password,
                        Active = mailbox.Active,
                        WelkomeMail = mailbox.WelkomeMail
                    };
                    _context.Mailboxes.Update(mdb);
                    _context.SaveChanges();
                    return "Success";
                }
                else return "No many mailbox in domain";
            }
            return "Error";
        }
        public string DelMail(int id)
        {
            MailboxDB mailboxDB = _context.Mailboxes.FirstOrDefault(m => m.Id == id);
            if (mailboxDB != null)
            {
                _context.Mailboxes.Remove(mailboxDB);
                _context.SaveChanges();
                return "Success";
            }
            return "Error";
        }
    }
}
