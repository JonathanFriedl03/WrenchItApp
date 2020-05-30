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
    public class ServiceTypeRepository : RepositoryBase<Service>, IServiceTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
               
        public void Update(ServiceType service)
        {
            throw new NotImplementedException();
            //var  objFromDb = _context.Services.FirstOrDefault(i => i.Id == service.Id);

            //objFromDb.Name = service.Name;
            //objFromDb.Description = service.Description;
            //objFromDb.PricePerHour = service.PricePerHour;
            //objFromDb.TimeOfJob = service.TimeOfJob;
            //objFromDb.ImageUrl = service.ImageUrl;
            //objFromDb.CategoryId = service.CategoryId;           

            //_context.SaveChanges();
        }
    }
}
