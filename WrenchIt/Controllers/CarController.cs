using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WrenchIt.Data;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Controllers
{
    public class CarController : Controller
    {
        private readonly IRepoWrapper _context;
        private readonly IWebHostEnvironment _hostEnvironment;



        public CarController(IRepoWrapper context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {

            var data = _context.Car.GetAll();
            return View(data);
        }

        public IActionResult Edit(int? id)
        {
            var car = new Car();


            if (id != null)
            {
                car = _context.Car.Get(id.GetValueOrDefault());
            }
            return View(car);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (car.Id == 0)
                {
                    //new service service type
                    car.CustomerId = 5;
                    _context.Car.Add(car);
                }
                else
                {
                    //edit service

                    _context.Car.Update(car);
                }
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(car);
            }
        }

    }
}