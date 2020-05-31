using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Contracts;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Data.RepositoryBase
{
    public class ServiceTypeRepository : RepositoryBase<ServiceType>, IServiceTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
               
        public void Update(ServiceType serviceType)
        {            
            var objFromDb = _context.ServiceTypes.FirstOrDefault(i => i.Id == serviceType.Id);
            objFromDb.Name = serviceType.Name;
            objFromDb.Description = serviceType.Description;
            objFromDb.Rate = serviceType.Rate;
            objFromDb.Category = serviceType.Category;


            _context.SaveChanges();
        }
    }
}
