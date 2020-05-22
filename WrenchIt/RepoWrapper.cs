using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Data.Repository.IRepository;
using WrenchIt.Models;


namespace WrenchIt.Data.Repository
{
    public class RepoWrapper : IRepoWrapper
    {
        private readonly ApplicationDbContext _context;

        public RepoWrapper(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }

        public ICategoryRepository Category { get; set; }

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
