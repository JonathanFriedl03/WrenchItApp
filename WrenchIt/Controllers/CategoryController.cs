using Microsoft.AspNetCore.Mvc;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepoWrapper  _context;

        public CategoryController(IRepoWrapper context)
        {
            _context = context;
        }

        // GET: Category
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _context.Category.GetAll() });
        }

        // GET: Category/Edit/5
        public IActionResult UpdateInsert(int? id)
        {
            Category category = new Category();
            if(id == null)
            {
                return View(category);
            }
            category = _context.Category.Get(id.GetValueOrDefault());
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if(category.Id == 0)
                {
                    _context.Category.Add(category);
                }
                else
                {
                    _context.Category.Update(category);
                }
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objectFromDb = _context.Category.Get(id);
            if (objectFromDb == null)
            {
                return Json(new { success = false, message = "Unable to delete." });
            }
            _context.Category.Remove(objectFromDb);
            _context.Save();
            return Json(new { success = true, message = "Delete successfull." });
        }

        // GET: Category/Details/5
        //        public async Task<IActionResult> Details(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var category = await _context.Category
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (category == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(category);
        //        }

        //        // GET: Category/Create
        //        public IActionResult Create()
        //        {
        //            return View();
        //        }

        //        // POST: Category/Create
        //        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] Category category)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                _context.Add(category);
        //                await _context.SaveChangesAsync();
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(category);
        //        }

        //        // GET: Category/Edit/5
        //        public async Task<IActionResult> Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var category = await _context.Category.FindAsync(id);
        //            if (category == null)
        //            {
        //                return NotFound();
        //            }
        //            return View(category);
        //        }

        //        // POST: Category/Edit/5
        //        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder")] Category category)
        //        {
        //            if (id != category.Id)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(category);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!CategoryExists(category.Id))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(category);
        //        }

        //        // GET: Category/Delete/5
        //        public async Task<IActionResult> Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);
        //            if (category == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(category);
        //        }

        //        // POST: Category/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(int id)
        //        {
        //            var category = await _context.Category.FindAsync(id);
        //            _context.Category.Remove(category);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool CategoryExists(int id)
        //        {
        //            return _context.Category.Any(e => e.Id == id);
        //        }
    }
}
