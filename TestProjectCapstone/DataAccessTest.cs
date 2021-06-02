using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagerCapstone;
using Microsoft.EntityFrameworkCore;
using Xunit;
using AppointmentManagerCapstone.DAL;
using AppointmentManagerCapstone.Data;
using Microsoft.EntityFrameworkCore.InMemory;

namespace TestProjectCapstone
{
    public class DataAccessTest
    {

        [Fact]

        public void Searches_By_Customer_Name()
        {
            ICustomerRepository repo = new CustomerRepository(GetMockContext());

            var customers = repo.GetCustomersByName("Paint");

            Assert.Equal(3, customers.Count);

        }

        private ApplicationDbContext GetMockContext()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            context.Customers.Add(new AppointmentManagerCapstone.Models.Customer { ID = 1, CustomerName="Paint Man", CustomerEmail="email@email.com", CustomerPhone="2326646754", CustomerCity=0, CreateDate=DateTime.Now, CustomerType=0 });
            context.Customers.Add(new AppointmentManagerCapstone.Models.Customer { ID = 2, CustomerName = "Sandwhich Man", CustomerEmail = "email@email.com", CustomerPhone = "2326646754", CustomerCity = 0, CreateDate = DateTime.Now, CustomerType = 0 });
            context.Customers.Add(new AppointmentManagerCapstone.Models.Customer { ID = 3, CustomerName = "Paint Man", CustomerEmail = "email@email.com", CustomerPhone = "2326646754", CustomerCity = 0, CreateDate = DateTime.Now, CustomerType = 0 });
            context.Customers.Add(new AppointmentManagerCapstone.Models.Customer { ID = 4, CustomerName = "Swim Pool Man", CustomerEmail = "email@email.com", CustomerPhone = "2326646754", CustomerCity = 0, CreateDate = DateTime.Now, CustomerType = 0 });
            context.Customers.Add(new AppointmentManagerCapstone.Models.Customer { ID = 5, CustomerName = "Paint Man", CustomerEmail = "email@email.com", CustomerPhone = "2326646754", CustomerCity = 0, CreateDate = DateTime.Now, CustomerType = 0 });

            context.SaveChanges();

            return context;

        }


    }
}
