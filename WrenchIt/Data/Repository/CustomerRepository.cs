using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Models;
using WrenchIt.Contracts;
using WrenchIt.Data.RepositoryBase;

namespace WrenchIt.Data
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Customer GetByUserId(string id)
        {
            return _context.Customers.Where(c => c.IdentityUserId == id).FirstOrDefault();
        }
    }
}
