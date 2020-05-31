using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WrenchIt.Data;
using WrenchIt.Data.RepositoryBase.IRepository;
using WrenchIt.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace WrenchIt.Controllers
{
    public class ServiceRequestController : Controller
    {
        private static string baseurl = "https://localhost:44361/api/";
        private static HttpClient client = new HttpClient();
        private readonly IRepoWrapper _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ServiceRequestController(IRepoWrapper context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var url = baseurl + "services";
            object data = null;
            try
            {
                var responseTask = client.GetAsync(url).Result;
                data = responseTask.Content.ReadAsStringAsync().Result;

            }
            catch (Exception exception)
            {
                data = exception;
            }

            dynamic response = JsonConvert.DeserializeObject(data.ToString());
            //List<ServiceRequest> results = response.ToObject<List<ServiceRequest>>();
            var viewModel = new List<ServiceRequestViewModel>();

            //foreach (var item in results)
            //{
            //    var model = viewModel.FirstOrDefault();
            //    if (model == null) //the transaction is unique
            //    {
            //        model = new ServiceRequestViewModel
            //        {
            //            Id = item.ServiceId,
            //            Name = _context.Service.Get(item.ServiceId).Name,
            //            Customer = _context.Customer.Get(item.CustomerId).FirstName,
            //            Quote = item.PriceQuotation,
            //            IsCompleted = item.IsCompleted,
            //            CreatedAt = item.CreatedAt
            //        };
            //        viewModel.Add(model);
            //    }
            //}






            return View(viewModel);
        }
    }
}
