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

        public IEnumerable<Service> GetAllServices()
        {

            return _context.Services.Include(c => c.ServiceType).OrderByDescending(c => c.Id).ToList();
        }

        public void Update(Service service)
        {
            var  objFromDb = _context.Services.FirstOrDefault(i => i.Id == service.Id);

            objFromDb.Name = service.Name;
            objFromDb.Description = service.Description;
            objFromDb.ServiceTypeId = service.ServiceTypeId;            
            objFromDb.ImageUrl = service.ImageUrl;
           // objFromDb.ServiceTypeId = service.ServiceTypeId;


            _context.SaveChanges();
        }
    }
}
