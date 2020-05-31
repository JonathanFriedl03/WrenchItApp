using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Controllers
{
    public class ServicesController : Controller
    {
        
        private readonly IRepoWrapper _context;
        private readonly IWebHostEnvironment _hostEnvironment;
      

       //public IEnumerable<SelectListItem> CategoryList { get; set; }

        public ServicesController(IRepoWrapper context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            return View();
        }

        ///////////////////////////////////////////////////////////////////////////
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Service job) this would be a job crontroller
        //{
        //    // make your API call
        //    // filter through the result to find the Customer's specific job type
        //    job.Price = //do the math

        //    _context.Jobs.Add(job);
        //    _context.Save();

        //    return View();
        //}
        ///////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Service.GetAllServices();
            return Json(new { data = _context.Service.GetAllServices()});
        }

        public IActionResult Edit(int? id)
        {
            ServiceViewModel serviceViewModel = new ServiceViewModel()
            {
                Service = new Models.Service(),
                ServiceTypeList = _context.ServiceType.GetAll()                
            };
            
            
            if (id != null)
            {
                serviceViewModel.Service = _context.Service.Get(id.GetValueOrDefault());
            }
            return View(serviceViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (service.Id == 0)
                {
                    //new service
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\servicePics");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    service.ImageUrl = @"\images\servicePics" + fileName + extension;
                    _context.Service.Add(service);
                }
                else
                {
                    //edit service
                    var serviceFromDb = _context.Service.Get(service.Id);
                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\servicePics");
                        var newExtension = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, serviceFromDb.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + newExtension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        service.ImageUrl = @"\images\servicePics\" + fileName + newExtension;

                    }
                    else
                    {
                        service.ImageUrl = serviceFromDb.ImageUrl;
                    }
                    _context.Service.Update(service);
                }
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(service);
            }
        }      

        // GET: Service/Delete/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var serviceFromDB = _context.Service.Get(id);
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, serviceFromDB.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            if (serviceFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting." });                
            }
            _context.Service.Remove(serviceFromDB);
            _context.Save();
            return Json(new { success = true, message = "Delete successful." });
        }

        // POST: Service/Delete/5
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