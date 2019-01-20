using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUnitOfWork<TC> : IDisposable where TC : DbContext, new()
    {
        IRepository<T> GetRepository<T>() where T : class;
        bool Save();
        Task SaveAsync();
        new void Dispose();
    }
}
