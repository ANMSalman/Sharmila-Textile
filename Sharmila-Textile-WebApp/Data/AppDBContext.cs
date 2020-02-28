using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.Data {
    public class AppDBContext : DbContext {
        public AppDBContext(DbContextOptions options) : base(options) { }
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
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<SupplierAccount> SupplierAccounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }

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



            modelBuilder.Entity<CustomerAccountOwnCheque>()
                .HasKey(t => new { t.OwnChequeId, t.CustomerAccountId });

            modelBuilder.Entity<CustomerAccountOwnCheque>()
                .HasOne(oc => oc.OwnCheque)
                .WithMany(x => x.CustomerAccountOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.OwnChequeId);

            modelBuilder.Entity<CustomerAccountOwnCheque>()
                .HasOne(sp => sp.CustomerAccount)
                .WithMany(x => x.CustomerAccountOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.CustomerAccountId);

            modelBuilder.Entity<CustomerAccountThirdPartyCheque>()
                .HasKey(t => new { t.ThirdPartyChequeId, t.CustomerAccountId });

            modelBuilder.Entity<CustomerAccountThirdPartyCheque>()
                .HasOne(oc => oc.ThirdPartyCheque)
                .WithMany(x => x.CustomerAccountThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.ThirdPartyChequeId);

            modelBuilder.Entity<CustomerAccountThirdPartyCheque>()
                .HasOne(sp => sp.CustomerAccount)
                .WithMany(x => x.CustomerAccountThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.CustomerAccountId);



            modelBuilder.Entity<SupplierAccountOwnCheque>()
                .HasKey(t => new { t.OwnChequeId, t.SupplierAccountId });

            modelBuilder.Entity<SupplierAccountOwnCheque>()
                .HasOne(oc => oc.OwnCheque)
                .WithMany(x => x.SupplierAccountOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.OwnChequeId);

            modelBuilder.Entity<SupplierAccountOwnCheque>()
                .HasOne(sp => sp.SupplierAccount)
                .WithMany(x => x.SupplierAccountOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.SupplierAccountId);

            modelBuilder.Entity<SupplierAccountThirdPartyCheque>()
                .HasKey(t => new { t.ThirdPartyChequeId, t.SupplierAccountId });

            modelBuilder.Entity<SupplierAccountThirdPartyCheque>()
                .HasOne(oc => oc.ThirdPartyCheque)
                .WithMany(x => x.SupplierAccountThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.ThirdPartyChequeId);

            modelBuilder.Entity<SupplierAccountThirdPartyCheque>()
                .HasOne(sp => sp.SupplierAccount)
                .WithMany(x => x.SupplierAccountThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.SupplierAccountId);



            modelBuilder.Entity<ExpenseOwnCheque>()
                .HasKey(t => new { t.OwnChequeId, t.ExpenseId });

            modelBuilder.Entity<ExpenseOwnCheque>()
                .HasOne(oc => oc.OwnCheque)
                .WithMany(x => x.ExpenseOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.OwnChequeId);

            modelBuilder.Entity<ExpenseOwnCheque>()
                .HasOne(sp => sp.Expense)
                .WithMany(x => x.ExpenseOwnCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.ExpenseId);

            modelBuilder.Entity<ExpenseThirdPartyCheque>()
                .HasKey(t => new { t.ThirdPartyChequeId, t.ExpenseId });

            modelBuilder.Entity<ExpenseThirdPartyCheque>()
                .HasOne(oc => oc.ThirdPartyCheque)
                .WithMany(x => x.ExpenseThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.ThirdPartyChequeId);

            modelBuilder.Entity<ExpenseThirdPartyCheque>()
                .HasOne(sp => sp.Expense)
                .WithMany(x => x.ExpenseThirdPartyCheques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(oc => oc.ExpenseId);
        }
    }
}
