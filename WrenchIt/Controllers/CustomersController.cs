using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WrenchIt.Data;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;

namespace WrenchIt.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static string baseurl = "https://localhost:44361/api";
        private static HttpClient client = new HttpClient();
        private readonly IRepoWrapper _newContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CustomersController(IRepoWrapper newContext, IWebHostEnvironment hostEnvironment, ApplicationDbContext context)
        {
            _context = context;
            _newContext = newContext;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customers.Include(c => c.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        public IActionResult ServiceRequests(int? id)
        {
            var uri = baseurl + "/services/GetServiceRequestByCustomerId/" + id;
            object data = null;
            try
            {
                var responseTask = client.GetAsync(uri).Result;
                data = responseTask.Content.ReadAsStringAsync().Result;
            }
            catch (Exception exception)
            {
                data = exception;
            }
            dynamic response = JsonConvert.DeserializeObject(data.ToString());
            List<ServiceRequest> results = response.ToObject<List<ServiceRequest>>();
            var viewModel = new List<ServiceRequestViewModel>();
            foreach (var item in results)
            {
                var model = viewModel.FirstOrDefault();

                model = new ServiceRequestViewModel
                {
                    Id = item.Id,
                    ServiceId = item.ServiceId,
                    Name = _newContext.Service.Get(item.ServiceId).Name,
                    Customer = _newContext.Customer.Get(item.CustomerId).FirstName,
                    Quote = item.PriceQuotation,
                    IsCompleted = item.IsCompleted,
                    CreatedAt = item.CreatedAt
                };
                viewModel.Add(model);
            }
            return View(viewModel);
        }
        public IActionResult CreateServiceRequest()
        {
            var viewModel = new CServiceRequestViewModel()
            {
                Service = new Models.Service(),
                ServiceList = _newContext.Service.GetAll()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateServiceRequest(ServiceRequest request)
        {
            var service = _newContext.Service.Get(request.Id);
            if (ModelState.IsValid)
            {
                return (RedirectToAction("ApproveServiceRequest", service));
            }
            return View(service);
        }
        public double CalculateQuote(int serviceId)
        {
            var service = _newContext.Service.GetServiceWithType(serviceId);
            double quote;
            if (service.ServiceType.Category == Category.Maintenance)
            {
                quote = service.ServiceType.Rate * 2;
            }
            else
            {
                quote = service.ServiceType.Rate * 5;
            }
            return quote;
        }
        public IActionResult ApproveServiceRequest(Service service)
        {
            var viewModel = new ApproveServiceViewModel()
            {
                Service = _newContext.Service.GetServiceWithType(service.Id),
                Quote = CalculateQuote(service.Id)
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Approve(IFormCollection formCollection)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var id = formCollection["serviceId"];
            var service = _newCont
                t.Service.Get(Convert.ToInt32(id));


            var test = _newContext.Customer.GetByUserId(userId).Id;

            var serviceRequest = new ServiceRequest()
            {
                ServiceId = service.Id,              
                CustomerId = _newContext.Customer.GetByUserId(userId).Id,
                PriceQuotation = CalculateQuote(service.Id),
                CreatedAt = DateTime.Now,
                IsCompleted = false
            };
            if (ModelState.IsValid)
            {
                object output = null;
                var url = baseurl + "/services/PostService";
                var jsonObject = JsonConvert.SerializeObject(serviceRequest);
                HttpContent context = new StringContent(jsonObject, System.Text.Encoding.UTF8, "application/json");
                try
                {
                    var responseTask = client.PostAsync(url, context).Result;
                    output = responseTask.Content.ReadAsStringAsync().Result;
                }
                catch (Exception exception)
                {
                    output = exception;
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(formCollection);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)

            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var userId = claim.Value;

                customer.IdentityUserId = userId;
                _context.Customers.Add(customer);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,City,State,ZipCode,Car,IdentityUserId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }
        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}