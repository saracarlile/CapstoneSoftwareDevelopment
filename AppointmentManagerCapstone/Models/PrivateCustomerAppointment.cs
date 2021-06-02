using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppointmentManagerCapstone.Models
{
    public class PrivateCustomerAppointment : Appointment
    {
        [Display(Name = "Mobile Setup Package")]
        public bool MobileSetupPackage { get; set; }
        [Display(Name = "Kids Safe Media Package")]
        public bool KidsSafeMediaPackage { get; set; }
        [Display(Name = "Workgroup Setup Package")]
        public bool WorkgroupSetupPackage { get; set; }
        [Required]
        [Display(Name = "Customer")]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
        [Required]
        [Display(Name = "Created By User")]
        public string CreatedByUser { get; set; }
    }
}
