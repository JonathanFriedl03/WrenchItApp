using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Data.RepositoryBase
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Car car)
        {
            var objFromDb = _context.Cars.FirstOrDefault(i => i.Id == car.Id);

            objFromDb.Name = car.Name;
            objFromDb.Miles = car.Miles;
            objFromDb.Model = car.Model;
            objFromDb.Vin = car.Vin;
            objFromDb.Year = car.Year;

            _context.SaveChanges();
        }
    }
}
