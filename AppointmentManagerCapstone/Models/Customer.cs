using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace AppointmentManagerCapstone.Models
{

    public class Customer
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Customer Email")]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Required]
        [Display(Name = "Customer Phone")]
        [Phone]
        public string CustomerPhone { get; set; }
        [Required]
        [Display(Name = "Customer City")]
        public CitiesEnum CustomerCity { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }
        [Required]
        [Display(Name = "Customer Type")]
        public CustomerTypesEnum CustomerType { get; set; }


        public enum CitiesEnum
        {
           [Display(Name = "San Antonio")]
           SanAntonio,
           Houston,
           Dallas
        }

        public enum CustomerTypesEnum
        {
            [Display(Name = "Business Customer")]
            BusinessCustomer = 0,
            [Display(Name = "Private Customer")]
            PrivateCustomer = 1
        }

    }
}
