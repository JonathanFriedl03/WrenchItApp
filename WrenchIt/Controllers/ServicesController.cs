using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WrenchIt.Data.Repository.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Controllers
{
    public class ServicesController : Controller
    {
        
        private readonly IRepoWrapper _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ServiceViewModel ServVM { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; private set; }

        public ServicesController(IRepoWrapper context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult UpdateInsert(int? id)
        {
            ServiceViewModel serviceViewModel = new ServiceViewModel()
            {
                Service = new Service(),
                CategoryList = _context.Category.GetCategoryListForDropDown()
            };
            return View(serviceViewModel);

        }
            // GET: Services/Edit/5
            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Services/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}