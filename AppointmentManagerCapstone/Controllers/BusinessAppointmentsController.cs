using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppointmentManagerCapstone.Data;
using AppointmentManagerCapstone.Models;

namespace AppointmentManagerCapstone.Controllers
{
    public class BusinessAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessAppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessAppointments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BusinessAppointments.Include(b => b.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BusinessAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAppointment = await _context.BusinessAppointments
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (businessAppointment == null)
            {
                return NotFound();
            }

            return View(businessAppointment);
        }

        // GET: BusinessAppointments/Create
        //public IActionResult Create()
        //{
        //    ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerName");
        //    return View();
        //}

        public IActionResult Create()
        {
            var customers = from c in _context.Customers
                            where c.CustomerType == Customer.CustomerTypesEnum.BusinessCustomer
                            select c;
            ViewData["CustomerID"] = new SelectList(customers, "ID", "CustomerName");
            return View();
        }

        // POST: BusinessAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailSetupPackage,DomainSetupPackage,SubscriptionSupportPackage,CustomerID,CreatedByUser,ID,AppointmentName,AppointmentNotes,AppointmentStart,AppointmentEnd")] BusinessAppointment businessAppointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(businessAppointment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
           
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerCity", businessAppointment.CustomerID);
            return View(businessAppointment);
        }

        // GET: BusinessAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAppointment = await _context.BusinessAppointments.FindAsync(id);
            if (businessAppointment == null)
            {
                return NotFound();
            }
            var customers = from c in _context.Customers
                            where c.CustomerType == Customer.CustomerTypesEnum.BusinessCustomer
                            select c;

            ViewData["CustomerID"] = new SelectList(customers, "ID", "CustomerName", businessAppointment.CustomerID);
            return View(businessAppointment);
        }



        // POST: BusinessAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmailSetupPackage,DomainSetupPackage,SubscriptionSupportPackage,CustomerID,CreatedByUser,ID,AppointmentName,AppointmentNotes,AppointmentStart,AppointmentEnd")] BusinessAppointment businessAppointment)
        {
            if (id != businessAppointment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessAppointmentExists(businessAppointment.ID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerCity", businessAppointment.CustomerID);
            return View(businessAppointment);
        }

        // GET: BusinessAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAppointment = await _context.BusinessAppointments
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (businessAppointment == null)
            {
                return NotFound();
            }

            return View(businessAppointment);
        }

        // POST: BusinessAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessAppointment = await _context.BusinessAppointments.FindAsync(id);
            _context.BusinessAppointments.Remove(businessAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessAppointmentExists(int id)
        {
            return _context.BusinessAppointments.Any(e => e.ID == id);
        }
    }
}
