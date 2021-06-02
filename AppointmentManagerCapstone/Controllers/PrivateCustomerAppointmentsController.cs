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
    public class PrivateCustomerAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrivateCustomerAppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrivateCustomerAppointments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PrivateCustomerAppointments.Include(p => p.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PrivateCustomerAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateCustomerAppointment = await _context.PrivateCustomerAppointments
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (privateCustomerAppointment == null)
            {
                return NotFound();
            }

            return View(privateCustomerAppointment);
        }

        // GET: PrivateCustomerAppointments/Create
        //public IActionResult Create()
        //{
        //    ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerName");
        //    return View();
        //}

        public IActionResult Create()
        {
            var customers = from c in _context.Customers
                            where c.CustomerType == Customer.CustomerTypesEnum.PrivateCustomer
                            select c;
            ViewData["CustomerID"] = new SelectList(customers, "ID", "CustomerName");
            return View();
        }

        // POST: PrivateCustomerAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MobileSetupPackage,KidsSafeMediaPackage,WorkgroupSetupPackage,CustomerID,CreatedByUser,ID,AppointmentName,AppointmentNotes,AppointmentStart,AppointmentEnd")] PrivateCustomerAppointment privateCustomerAppointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(privateCustomerAppointment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Unable to save changes. " +
                   "Try again, and if the problem persists " +
                   "see your system administrator.");
            }
           
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerName", privateCustomerAppointment.CustomerID);
            return View(privateCustomerAppointment);
        }

        // GET: PrivateCustomerAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateCustomerAppointment = await _context.PrivateCustomerAppointments.FindAsync(id);
            if (privateCustomerAppointment == null)
            {
                return NotFound();
            }
            var customers = from c in _context.Customers
                            where c.CustomerType == Customer.CustomerTypesEnum.PrivateCustomer
                            select c;
            ViewData["CustomerID"] = new SelectList(customers, "ID", "CustomerName", privateCustomerAppointment.CustomerID);
            return View(privateCustomerAppointment);
        }

        // POST: PrivateCustomerAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MobileSetupPackage,KidsSafeMediaPackage,WorkgroupSetupPackage,CustomerID,CreatedByUser,ID,AppointmentName,AppointmentNotes,AppointmentStart,AppointmentEnd")] PrivateCustomerAppointment privateCustomerAppointment)
        {
            if (id != privateCustomerAppointment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privateCustomerAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivateCustomerAppointmentExists(privateCustomerAppointment.ID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerCity", privateCustomerAppointment.CustomerID);
            return View(privateCustomerAppointment);
        }

        // GET: PrivateCustomerAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateCustomerAppointment = await _context.PrivateCustomerAppointments
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (privateCustomerAppointment == null)
            {
                return NotFound();
            }

            return View(privateCustomerAppointment);
        }

        // POST: PrivateCustomerAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var privateCustomerAppointment = await _context.PrivateCustomerAppointments.FindAsync(id);
            _context.PrivateCustomerAppointments.Remove(privateCustomerAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivateCustomerAppointmentExists(int id)
        {
            return _context.PrivateCustomerAppointments.Any(e => e.ID == id);
        }
    }
}
