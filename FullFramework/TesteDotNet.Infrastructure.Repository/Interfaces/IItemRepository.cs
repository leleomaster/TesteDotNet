using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.Domain;
using TesteDotNet.Infrastructure.Repository.Interfaces.Bases;

namespace TesteDotNet.Infrastructure.Repository.Interfaces
{
    public interface IItemRepository : IRepositoryBaseAction<ItemDomain>, IRepositoryBaseQuery<ItemDomain>
    {
        IEnumerable<ItemDomain> Find(ItemDomain item);
        bool HasNameEqual(string name);
    }
}
