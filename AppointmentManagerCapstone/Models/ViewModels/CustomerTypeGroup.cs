using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentManagerCapstone.Data;
using AppointmentManagerCapstone.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagerCapstone.Models.ViewModels
{
    public class CustomerTypeGroup
    {

     
        public CustomerTypesEnum CustomerType { get; set; }
        
        public int CustomerTypeCount { get; set; }


        public enum CustomerTypesEnum
        {

            BusinessCustomer = 0,
            PrivateCustomer = 1
        }

    }
}
