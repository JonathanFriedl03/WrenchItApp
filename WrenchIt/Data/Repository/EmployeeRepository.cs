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

    }
}
