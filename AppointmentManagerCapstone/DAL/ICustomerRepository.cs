using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentManagerCapstone.Models;

namespace AppointmentManagerCapstone.DAL
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomersByName(string custName);
    }
}
