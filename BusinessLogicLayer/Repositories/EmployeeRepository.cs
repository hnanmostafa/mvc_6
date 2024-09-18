



using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Demo.BusinessLogicLayer.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(DataContext context) : base(context) 
        {
        
        }
        public IEnumerable<Employee> GetAll(string name)
        {
          return _dbSet.Where(e=>e.Name.ToLower().Contains( name.ToLower())).Include(e => e.Department).ToList();
        }

        public IEnumerable<Employee> GetAllwithDepartment()
        {
            return _dbSet.Include(e=>e.Department).ToList();
        }
    }
}
