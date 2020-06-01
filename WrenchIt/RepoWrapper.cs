using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Contracts;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;



namespace WrenchIt.Data.RepositoryBase
{
    public class RepoWrapper : IRepoWrapper
    {
        private readonly ApplicationDbContext _context;

        public RepoWrapper(ApplicationDbContext context)
        {
            _context = context;
            Service = new ServiceRepository(_context);
            ServiceType = new ServiceTypeRepository(_context);
            Car = new CarRepository(_context);
            Employee = new EmployeeRepository(_context);
            Customer = new CustomerRepository(_context);
        }


        public IServiceRepository Service { get; private set; }

        public IServiceTypeRepository ServiceType { get; private set; }

        public ICarRepository Car { get; private set; }

        public IEmployeeRepository Employee { get; private set; }

        public ICustomerRepository Customer { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
