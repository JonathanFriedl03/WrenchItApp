using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Contracts;
using WrenchIt.Data;

namespace WrenchIt
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private ICustomerRepository _customer;
        //private IFlightRepository _flight;
        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_context);
                }
                return _customer;
            }
        }

        //change name below to necessary model class if added later
        //public IFlightRepository Flight 
        //{
        //    get
        //    {
        //        if (_flight == null)
        //        {
        //            _flight = new FlightRepository(_context);
        //        }
        //        return _flight;
        //    }
        //}
        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
