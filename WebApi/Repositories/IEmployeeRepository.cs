using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> Create(Employee employee);
        Task<bool> DeleteById(int id);
        IQueryable<Employee> EmployeeById(int id);
        IQueryable<Employee> Employees();
        Task<bool> Update(Employee employee);
    }
}