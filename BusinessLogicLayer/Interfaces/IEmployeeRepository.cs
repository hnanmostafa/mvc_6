

namespace Demo.BusinessLogicLayer.Interfaces
{
   public interface IEmployeeRepository: IGendericRepository<Employee>
    {
        public IEnumerable<Employee> GetAll(string name);
        IEnumerable<Employee> GetAllwithDepartment();
    }
}
