using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPostfix.Models;

namespace TestPostfix.DAL
{
    public interface IDomainRepository
    {
        IEnumerable<Domain> DomainList();
        string DomainAdded(Domain domain);
        Domain DomainGet(int id);
        string DomainEdit(Domain domain);
        string DomainDel(int id);
    }
}
