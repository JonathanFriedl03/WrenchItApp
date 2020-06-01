using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WrenchIt.Data.RepositoryBase.IRepository;

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
    }
}