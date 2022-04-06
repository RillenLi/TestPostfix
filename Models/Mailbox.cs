using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TestPostfix.DBModels;

namespace TestPostfix.Models
{
    public class Mailbox
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name not specified")]
        public string Username { get; set; }
        [Required(ErrorMessage = "No domain selected")]
        public int DomainId { get; set; }
        public Domain Domain { get; set; }
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Repeat the password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public bool WelkomeMail { get; set; }
        public string MError { get; set; }
        public Mailbox() { }
        public Mailbox(string e)
        {
            MError = e;
        }
        public Mailbox(MailboxDB mailboxDB)
        {
            Id = mailboxDB.Id;
            Username = mailboxDB.Username;
            DomainId = mailboxDB.DomainDBId;
            Domain = new Domain(mailboxDB.DomainDB);
            Password = mailboxDB.Password;
            Name = mailboxDB.Name;
            Active = mailboxDB.Active;
            WelkomeMail = mailboxDB.WelkomeMail;
        }

    }
}
