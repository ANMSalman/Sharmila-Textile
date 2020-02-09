using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.Data {
    public class AppDBContext : DbContext {
        public AppDBContext(DbContextOptions options) : base(options) {

        }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffAttachment> StaffAttachment { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAttachment> CustomerAttachment { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierAttachment> SupplierAttachment { get; set; }

    }
}
