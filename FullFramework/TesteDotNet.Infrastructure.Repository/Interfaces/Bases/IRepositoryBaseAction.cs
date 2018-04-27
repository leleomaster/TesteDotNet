using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.Infrastructure.Repository.Interfaces.Bases
{
    public interface IRepositoryBaseAction<T> where T : class
    {
        void Add(T t);
        void Update(T t);
        void Delete(int id);
    }
}
