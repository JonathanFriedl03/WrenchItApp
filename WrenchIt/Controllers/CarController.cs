using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WrenchIt.Data;

namespace WrenchIt.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;



        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}