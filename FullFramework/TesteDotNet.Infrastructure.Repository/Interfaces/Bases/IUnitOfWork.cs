using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.Infrastructure.Repository.Interfaces.Bases
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
