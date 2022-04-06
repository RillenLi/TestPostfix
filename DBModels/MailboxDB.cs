using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TestPostfix.DBModels
{
    public class MailboxDB
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int DomainDBId { get; set; }
        public DomainDB DomainDB { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool WelkomeMail { get; set; }

    }
}
