using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentManagerCapstone.Models;
using System.Text;
using AppointmentManagerCapstone.Data;
using AppointmentManagerCapstone.DAL;

namespace AppointmentManagerCapstone.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> GetCustomersByName(string name) => _context.Customers.Where(c => c.CustomerName.Contains(name)).ToList();

    }
}
