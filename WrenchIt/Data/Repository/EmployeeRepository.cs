using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Models;
using WrenchIt.Contracts;
using WrenchIt.Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace WrenchIt.Data
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        //public EmployeeRepository(ApplicationDbContext applicationDbContext)
        //    : base(applicationDbContext)
        //{
        //}
        //public Employee GetCustomer(int? customerId) =>
        //    FindByCondition(c => c.Id.Equals(customerId)).SingleOrDefault();
        //public Employee GetCustomer(string userId)
        //{
        //    var customer = FindByCondition(c => c.IdentityUserId.Equals(userId)).SingleOrDefault();
        //    return customer;
        //}
        //public void CreateCustomer(Employee employee) => Create(employee);
        //public void EditCustomer(Employee employee)
        //{
        //    Update(employee);
        //}
        //public void DeleteCustomer(int employeeId)
        //{
        //    var employeeToDelete = FindByCondition(c => c.Id.Equals(employeeId)).SingleOrDefault();
        //    Delete(employeeToDelete);
        //}

    }
}
