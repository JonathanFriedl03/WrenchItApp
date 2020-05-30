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
            //return Json(new { data = _context.ServiceType.GetAll(includeProperties: "Category") });
            return Json(new { data = _context.ServiceType.GetAll() });
        }

        public IActionResult Edit(int? id)
        {

            ServiceViewModel serviceViewModel = new ServiceViewModel()
            {
                Service = new Models.Service(),
                ServiceTypeList = _context.ServiceType.GetAll()
                //   CategoryList = _context.Category.GetCategoryListForDropDown(),
            };


            if (id != null)
            {
                serviceViewModel.Service = _context.Service.Get(id.GetValueOrDefault());
            }
            return View(new ServiceType());

        }

    }
}