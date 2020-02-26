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
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffAttachment> StaffAttachments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAttachment> CustomerAttachments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierAttachment> SupplierAttachments { get; set; }
        public DbSet<ChequeStatus> ChequeStatuses { get; set; }
        public DbSet<OwnCheque> OwnCheques { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<OwnChequeActionLog> OwnChequeActionLogs { get; set; }
        public DbSet<ThirdPartyCheque> ThirdPartyCheques { get; set; }
        public DbSet<ThirdPartyChequeActionLog> ThirdPartyChequeActionLogs { get; set; }
        public DbSet<SupplierPayment> SupplierPayments { get; set; }
        public DbSet<Collection> Collections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<SupplierPaymentOwnCheque>()
               .HasKey(t => new { t.OwnChequeId, t.SupplierPaymentId });

            modelBuilder.Entity<SupplierPaymentOwnCheque>()
                .HasOne(oc => oc.OwnCheque)
                .WithMany(x => x.SupplierPaymentOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.OwnChequeId);

            modelBuilder.Entity<SupplierPaymentOwnCheque>()
                .HasOne(sp => sp.SupplierPayment)
                .WithMany(x => x.SupplierPaymentOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.SupplierPaymentId);

            modelBuilder.Entity<SupplierPaymentThirdPartyCheque>()
                .HasKey(t => new { t.ThirdPartyChequeId, t.SupplierPaymentId });

            modelBuilder.Entity<SupplierPaymentThirdPartyCheque>()
                .HasOne(oc => oc.ThirdPartyCheque)
                .WithMany(x => x.SupplierPaymentThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.ThirdPartyChequeId);

            modelBuilder.Entity<SupplierPaymentThirdPartyCheque>()
                .HasOne(sp => sp.SupplierPayment)
                .WithMany(x => x.SupplierPaymentThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.SupplierPaymentId);




            modelBuilder.Entity<CollectionOwnCheque>()
                .HasKey(t => new { t.OwnChequeId, t.CollectionId });

            modelBuilder.Entity<CollectionOwnCheque>()
                .HasOne(oc => oc.OwnCheque)
                .WithMany(x => x.CollectionOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.OwnChequeId);

            modelBuilder.Entity<CollectionOwnCheque>()
                .HasOne(sp => sp.Collection)
                .WithMany(x => x.CollectionOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.CollectionId);

            modelBuilder.Entity<CollectionThirdPartyCheque>()
                .HasKey(t => new { t.ThirdPartyChequeId, t.CollectionId });

            modelBuilder.Entity<CollectionThirdPartyCheque>()
                .HasOne(oc => oc.ThirdPartyCheque)
                .WithMany(x => x.CollectionThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.ThirdPartyChequeId);

            modelBuilder.Entity<CollectionThirdPartyCheque>()
                .HasOne(sp => sp.Collection)
                .WithMany(x => x.CollectionThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.CollectionId);

        }
    }
}
