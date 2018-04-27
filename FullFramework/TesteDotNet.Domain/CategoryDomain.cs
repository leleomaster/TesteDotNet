using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.Domain
{
   public class CategoryDomain
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ItemDomain> Itens { get; set; }
    }
}
