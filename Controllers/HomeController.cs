using System;
using DigitalAviator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using MapIntegration.Models;

namespace DigitalAviator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            LocationLists model = new LocationLists();
            var locations = new List<Locations>()
            {
                new Locations(1, "LBSF", "Bhubaneswar, Odisha", 42.690434, 23.403122),
                new Locations(2, "LBPD", "Hyderabad, Telengana", 42.076188, 24.844043)
            };
            model.LocationList = locations;
            return View(model);
        }

        [Route("myroute/{pic}")]
        public IActionResult Get(string pic)
        {
            Byte[] b = System.IO.File.ReadAllBytes("image/" + pic);
            return File(b, "image/jpeg");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
