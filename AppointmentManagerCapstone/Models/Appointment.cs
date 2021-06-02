using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppointmentManagerCapstone.Models;

namespace AppointmentManagerCapstone.Models
{
    public abstract class Appointment
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Appointment Name")]
        public string AppointmentName { get; set; }
        [Display(Name = "Appointment Notes")]
        [Required]
        public string AppointmentNotes { get; set; }
        [AppointmentClass]
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Appointment Start")]
        public DateTime AppointmentStart { get; set; }
        [AppointmentClass]
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Appointment End")]
        public DateTime AppointmentEnd { get; set; }

     
    }
}
