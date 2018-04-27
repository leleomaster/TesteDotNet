using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.Infrastructure.Repository.Interfaces.Bases
{
    public interface IRepositoryBaseQuery<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
