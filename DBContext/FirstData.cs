using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPostfix.Models;
using TestPostfix.DBModels;

namespace TestPostfix.DB
{
    public static class FirstData
    {
        public static void Init(AdmContext context)
        {
            if (!context.Domains.Any())
            {
                DomainDB dm = new DomainDB
                {
                    Name = "example.com",
                    Description = "Example domain",
                    DefaultAliases = false,
                    BackupMX = true,
                    MaxAlias = 5,
                    MaxMailbox = 10,
                    Aliases = new List<AliasDB>(),
                    Mailboxes = new List<MailboxDB>()
                };
                context.Add(dm);
                context.SaveChanges();
            }
            if (!context.Aliases.Any())
            {
                AliasDB al= new AliasDB
                {
                    Name = "something",
                    MailToSent = "sometthing@yandex.ru",
                    DomainDBId=1,
                    Active=true
                };
                context.Add(al);
                context.SaveChanges();
            }
            if (!context.Mailboxes.Any())
            {
                MailboxDB ml = new MailboxDB
                {
                    Username = "user",
                    Password = "123",
                    Name = "Any User",
                    Active = true,
                    DomainDBId = 1,
                    WelkomeMail=false
                };
                context.Add(ml);
                context.SaveChanges();
            }
        }
    }
}
