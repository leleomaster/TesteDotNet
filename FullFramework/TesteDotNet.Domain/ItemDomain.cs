using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.Domain
{
    public class ItemDomain
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateAlter { get; set; }

        public CategoryDomain Category { get; set; }
    }
}
