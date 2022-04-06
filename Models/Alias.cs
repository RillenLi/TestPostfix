using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TestPostfix.DBModels;

namespace TestPostfix.Models
{
    public class Alias
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Не указано имя")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage ="Неверный email")]
        public string MailToSent { get; set; }
        [Required(ErrorMessage = "Не выбран домен")]
        public int DomainId{get;set;}
        public Domain Domain { get; set; }
        public bool Active { get; set; } = false;
        public string AError { get; set; }
        public Alias() { }
        public Alias(AliasDB aliasDB)
        {
            Id = aliasDB.Id;
            Name = aliasDB.Name;
            MailToSent = aliasDB.MailToSent;
            DomainId = aliasDB.DomainDBId;
            Domain = new Domain(aliasDB.DomainDB);
            Active = aliasDB.Active;
        }
        public Alias(string e)
        {
            AError = e;
        }
    }
}
