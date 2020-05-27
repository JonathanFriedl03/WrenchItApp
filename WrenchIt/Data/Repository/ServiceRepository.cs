using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Data.RepositoryBase
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
               
        public void Update(Service service)
        {
            var  objFromDb = _context.Services.FirstOrDefault(i => i.Id == service.Id);

            objFromDb.Name = service.Name;
            objFromDb.Description = service.Description;
            objFromDb.Price = service.Price;
            objFromDb.ImageUrl = service.ImageUrl;
            objFromDb.CategoryId = service.CategoryId;
            objFromDb.LaborId = service.LaborId;

            _context.SaveChanges();
        }
    }
}
