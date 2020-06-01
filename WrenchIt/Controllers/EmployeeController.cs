using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {

        private readonly IRepoWrapper _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public EmployeesController(IRepoWrapper context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Employee.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Add(employee);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
    }
}