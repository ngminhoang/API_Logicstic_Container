using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    public class CFcontext: DbContext
    {
        public CFcontext(DbContextOptions<CFcontext> options) : base(options)  { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Huyen>()
            //   .HasKey(h => new { h.Tid, h.Hid }); // Composite key configuration
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Bussiness> Bussinesss { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vihcle> Vihcles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DriverRate> DriverRates { get; set; }
        public DbSet<AppRate> AppRates { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuss { get; set; }
        public DbSet<Status> Statuss { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotifType> NotifTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Counting> Countings { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
