using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPostfix.Models;

namespace TestPostfix.DAL
{
    public interface IMailRepository
    {
        IEnumerable<Mailbox> ListMailbox();
        string AddMail(Mailbox mailbox);
        Mailbox GetMailbox(int id);
        string EditMail(Mailbox mailbox);
        string DelMail(int id);
    }
}
