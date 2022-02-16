using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MindreanDenisaProject.Data;
using MindreanDenisaProject.Models;


namespace MindreanDenisaProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ShelterContext _context;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, ShelterContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        /* public async Task<ActionResult> Statistics()
         {
             IQueryable<OrderGroup> data =
             from order in _context.Orders
             group order by order.OrderDate into dateGroup
             select new OrderGroup()
             {
                 OrderDate = dateGroup.Key,
                 BookCount = dateGroup.Count()
             };
             return View(await data.AsNoTracking().ToListAsync());
         }*/
    }
}
