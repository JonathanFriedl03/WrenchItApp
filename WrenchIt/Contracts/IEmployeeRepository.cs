using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Contracts
{
    public interface IEmployeeRepository : IRepoBase<Employee>
    {
        //Employee GetEmployee(int? employeeId);
        //Employee GetEmployee(string userId);
        //void CreateEmployee(Employee employee);
        //void EditEmployee(Employee employee);
        //void DeleteEmployee(int employeeId);
    }
}
