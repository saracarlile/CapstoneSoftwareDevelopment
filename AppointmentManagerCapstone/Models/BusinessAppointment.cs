using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagerCapstone.Models
{
    public class BusinessAppointment : Appointment
    {
        [Display(Name = "Email Setup Package")]
        public bool EmailSetupPackage { get; set; }
        [Display(Name = "Domain Setup Package")]
        public bool DomainSetupPackage { get; set; }
        [Display(Name = "Subscription Support Package")]
        public bool SubscriptionSupportPackage { get; set; }
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
