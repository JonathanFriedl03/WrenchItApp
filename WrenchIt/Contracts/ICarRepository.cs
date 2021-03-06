﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Models;

namespace WrenchIt.Data.RepositoryBase.IRepository
{
    public interface ICarRepository : IRepoBase<Car>
    {
        IEnumerable<Car> GetCustomerCars(int id);
        void Update(Car car);
        
    }
}
