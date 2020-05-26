//using Microsoft.AspNetCore.Mvc.Rendering;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WrenchIt.Contracts;
//using WrenchIt.Models;

//namespace WrenchIt.Data.RepositoryBase
//{
//    public class LaborRepository : RepositoryBase<Labor>, ILaborRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public LaborRepository(ApplicationDbContext context) : base(context)
//        {
//            _context = context;
//        }
//        public IEnumerable<SelectListItem> GetLaborListForDropDown()
//        {
//            return _context.Category.Select(i => new SelectListItem()
//            {
//                Text = i.Name,
//                Value = i.Id.ToString()
//            });
//        }
//        public void Update(Labor labor)
//        {
//            var objFromDb = _context.Labor.FirstOrDefault(i => i.Id == labor.Id);

//            objFromDb.Name


//        }
//    }
//}
