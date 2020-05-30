using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Controllers
{
    public class ServiceTypeController : Controller
    {
        private readonly IRepoWrapper _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ServiceTypeController(IRepoWrapper context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _context.ServiceType.GetAll();            
            return Json(new { data = _context.ServiceType.GetAll() });
        }
    }
}