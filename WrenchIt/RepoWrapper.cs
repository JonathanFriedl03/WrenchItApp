using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Category = new CategoryRepository(_context);
            Service = new ServiceRepository(_context);
           // Labor = new LaborRepository(_context);
        }

        public ICategoryRepository Category { get; set; }
        public IServiceRepository Service { get; set; }

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
