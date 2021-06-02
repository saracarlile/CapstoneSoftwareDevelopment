using AppointmentManagerCapstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppointmentManagerCapstone.Data;
using AppointmentManagerCapstone.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagerCapstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public async Task<ActionResult> About()
        {
            IQueryable<CustomerTypeGroup> data =
                from customer in _context.Customers
                group customer by customer.CustomerType into customerGroup
                select new CustomerTypeGroup()
                {
                    CustomerType = (CustomerTypeGroup.CustomerTypesEnum)customerGroup.Key,
                    CustomerTypeCount = customerGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public async Task<ActionResult> FutureBusiness()
        {
            var appointments = from b in _context.BusinessAppointments.Include(b => b.Customer)
                               select b;
            appointments = appointments.Where(x => x.AppointmentStart >= DateTime.Now);

            return View(await appointments.AsNoTracking().ToListAsync());

        }

        public async Task<ActionResult> FuturePrivate()
        {
            var appointments = from p in _context.PrivateCustomerAppointments.Include(b => b.Customer)
                               select p;
            appointments = appointments.Where(x => x.AppointmentStart >= DateTime.Now);

            return View(await appointments.AsNoTracking().ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
