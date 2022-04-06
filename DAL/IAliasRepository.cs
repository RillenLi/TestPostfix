using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPostfix.Models;


namespace TestPostfix.DAL
{
    public interface IAliasRepository
    {
        IEnumerable<Alias> AliasList();
        string AddAlias(Alias alias);
        string EditAlias(Alias alias);
        Alias GetAlias(int id);
        string DelAlias(int id);
    }
}
