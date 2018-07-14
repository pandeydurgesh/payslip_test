using PaySlip.DAL.CustomModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip.DAL.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        PaySlipModel GetPaySplip();
    }

    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
    
        private readonly DbSet<Employee> _dbSet;
       
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException();
            _dbSet = unitOfWork.DatabaseContext.Set<Employee>();
        }

        public PaySlipModel GetPaySplip() {
            return new PaySlipModel();
        }
    }
}
