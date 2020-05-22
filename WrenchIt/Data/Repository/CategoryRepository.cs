using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Data.Repository.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Data.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
           return _context.Category.Select(i => new SelectListItem()
           { 
                Text = i.Name,
                Value = i.Id.ToString()
           });
        }

        public void Update(Category category)
        {
            var  objFromDb = _context.Category.FirstOrDefault(i => i.Id == category.Id);

            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;

            _context.SaveChanges();
        }
    }
}
