using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentManagerCapstone.Models;

namespace AppointmentManagerCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<BusinessAppointment> BusinessAppointments { get; set; }

        public DbSet<PrivateCustomerAppointment> PrivateCustomerAppointments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<BusinessAppointment>().ToTable("BusinessAppointment");
            modelBuilder.Entity<PrivateCustomerAppointment>().ToTable("PrivateCustomerAppointment");
        }
    }
}
