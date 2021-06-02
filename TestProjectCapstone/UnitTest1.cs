using System;
using Xunit;
using AppointmentManagerCapstone.Models;

namespace TestProjectCapstone
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var xValue = Customer.CustomerTypesEnum.BusinessCustomer;

            Assert.Equal(0, (int)xValue);

        }
    }
}
