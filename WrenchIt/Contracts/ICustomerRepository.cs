using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Contracts
{
    public interface ICustomerRepository : IRepoBase<Customer>
    {
        //Customer GetCustomer(int? customerId);
        //Customer GetCustomer(string userId);
        //void CreateCustomer(Customer customer);
        //void EditCustomer(Customer customer);
        //void DeleteCustomer(int customerId);
    }
}
