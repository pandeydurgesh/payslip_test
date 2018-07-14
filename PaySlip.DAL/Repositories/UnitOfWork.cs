using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip.DAL.Repositories
{

    public interface IUnitOfWork : IDisposable
    {
        
        DbContext DatabaseContext { get; }
       
        void Commit();
        
        Task CommitAsync();
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DbContext DatabaseContext => throw new NotImplementedException();

        public void Commit() {
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
