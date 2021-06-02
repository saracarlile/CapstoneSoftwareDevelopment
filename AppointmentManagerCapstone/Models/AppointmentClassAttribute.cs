using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppointmentManagerCapstone.Models;


namespace AppointmentManagerCapstone.Models
{
    public class AppointmentClassAttribute : ValidationAttribute
    {

        public string GetErrorMessage() =>
        "Appointments must be scheduled Monday through Friday from 8am to 5pm! Appointment Start cannot be scheduled before Appointment End!";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var appointment = (Appointment)validationContext.ObjectInstance;

            if ( appointment.AppointmentStart.DayOfWeek == DayOfWeek.Saturday || appointment.AppointmentStart.DayOfWeek == DayOfWeek.Sunday ||
                appointment.AppointmentEnd.DayOfWeek == DayOfWeek.Saturday || appointment.AppointmentEnd.DayOfWeek == DayOfWeek.Sunday || 
                appointment.AppointmentStart.Hour < 8 || appointment.AppointmentEnd.Hour < 8 || appointment.AppointmentStart.Hour > 17  || 
                appointment.AppointmentEnd.Hour > 17  || appointment.AppointmentStart > appointment.AppointmentEnd)
                
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }


    }
}
