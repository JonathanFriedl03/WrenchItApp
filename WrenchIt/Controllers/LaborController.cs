using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Controllers
{
    public class LaborController : Controller
    {

        private readonly IRepoWrapper _context;

        public LaborController(IRepoWrapper context)
        {
            _context = context;
        }

        // GET: Labor
        public ActionResult Index()
        {
            return View();
        }
       
        // GET: Labor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Labor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Labor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Labor/Edit/5
        public IActionResult Edit(int? id)
        {
            Labor labor = new Labor();
            if (id == null)
            {
                return View(labor);
            }
            labor = _context.Labor.Get(id.GetValueOrDefault());
            if (labor == null)
            {
                return NotFound();
            }
            return View(labor);
        }
        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Labor labor)
        {
            if (ModelState.IsValid)
            {
                if (labor.Id == 0)
                {
                    _context.Labor.Add(labor);
                }
                else
                {
                    _context.Labor.Update(labor);
                }
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(labor);
        }
        // GET: Labor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Labor/Delete/5
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