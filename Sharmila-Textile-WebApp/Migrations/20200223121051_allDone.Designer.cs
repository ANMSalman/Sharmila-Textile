﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sharmila_Textile_WebApp.Data;

namespace Sharmila_Textile_WebApp.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20200223121051_allDone")]
    partial class allDone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.ChequeStatus", b =>
                {
                    b.Property<long>("ChequeStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CHEQUE_STATUS_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnName("STATUS_NAME")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ChequeStatusId");

                    b.ToTable("CHEQUE_STATUS");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CUSTOMER_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnType("datetime");

                    b.Property<decimal>("CurrentBalance")
                        .HasColumnName("CURRENT_BALANCE")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CurrentStatus")
                        .HasColumnName("CURRENT_STATUS")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnName("CUSTOMER_NAME")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("HomeAddress")
                        .HasColumnName("HOME_ADDRESS")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("HomeLandline")
                        .HasColumnName("HOME_LAND_LINE")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("Mobile")
                        .HasColumnName("MOBILE")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("NIC")
                        .HasColumnName("NIC")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("OfficeAddress")
                        .HasColumnName("OFFICE_ADDRESS")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("OfficeLandline")
                        .HasColumnName("OFFICE_LAND_LINE")
                        .HasColumnType("nchar(10)");

                    b.Property<decimal>("OpeningBalance")
                        .HasColumnName("OPENING_BALANCE")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("CUSTOMER");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.CustomerAttachment", b =>
                {
                    b.Property<long>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ATTACHMENT_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmentName")
                        .HasColumnName("ATTACHMENT_NAME")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("AttachmentPath")
                        .HasColumnName("ATTACHMENT_PATH")
                        .HasColumnType("varchar(max)");

                    b.Property<long>("CustomerId")
                        .HasColumnName("CUSTOMER_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("MimeType")
                        .HasColumnName("MIME_TYPE")
                        .HasColumnType("varchar(200)");

                    b.HasKey("AttachmentId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CUSTOMER_ATTACHMENT");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.OwnCheque", b =>
                {
                    b.Property<long>("OwnChequeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OWN_CHEQUE_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("AMOUNT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Bank")
                        .HasColumnName("BANK")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Branch")
                        .HasColumnName("BRANCH")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("ChequeCode")
                        .HasColumnName("CHEQUE_CODE")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnName("DUE_DATE")
                        .HasColumnType("datetime");

                    b.Property<string>("Remark")
                        .HasColumnName("REMARK")
                        .HasColumnType("varchar(100)");

                    b.Property<long>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("bigint");

                    b.HasKey("OwnChequeId");

                    b.HasIndex("Status");

                    b.ToTable("OWN_CHEQUE");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.OwnChequeActionLog", b =>
                {
                    b.Property<long>("OwnChequeActionLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OWN_CHEQUE_ACTION_LOG_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ChequeStatusId")
                        .HasColumnName("CHEQUE_STATUS_ID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("datetime");

                    b.Property<long>("OwnChequeId")
                        .HasColumnName("OWN_CHEQUE_ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("RecipientId")
                        .HasColumnName("RECIPIENT_ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReferenceId")
                        .HasColumnName("REFERENCE_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("bigint");

                    b.HasKey("OwnChequeActionLogId");

                    b.HasIndex("ChequeStatusId");

                    b.HasIndex("OwnChequeId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("UserId");

                    b.ToTable("OWN_CHEQUE_ACTION_LOG");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.Recipient", b =>
                {
                    b.Property<long>("RecipientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RECIPIENT_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecipientType")
                        .HasColumnName("RECIPIENT_TYPE")
                        .HasColumnType("varchar(70)");

                    b.HasKey("RecipientId");

                    b.ToTable("RECIPIENT");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.Staff", b =>
                {
                    b.Property<long>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("STAFF_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("ADDRESS")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnName("CONTACT_NO")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("CurrentStatus")
                        .HasColumnName("CURRENT_STATUS")
                        .HasColumnType("int");

                    b.Property<string>("Nic")
                        .HasColumnName("NIC")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("StaffName")
                        .HasColumnName("STAFF_NAME")
                        .HasColumnType("varchar(50)");

                    b.HasKey("StaffId");

                    b.ToTable("STAFF");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.StaffAttachment", b =>
                {
                    b.Property<long>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ATTACHMENT_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmentName")
                        .HasColumnName("ATTACHMENT_NAME")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("AttachmentPath")
                        .HasColumnName("ATTACHMENT_PATH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("MimeType")
                        .HasColumnName("MIME_TYPE")
                        .HasColumnType("varchar(200)");

                    b.Property<long>("StaffId")
                        .HasColumnName("STAFF_ID")
                        .HasColumnType("bigint");

                    b.HasKey("AttachmentId");

                    b.HasIndex("StaffId");

                    b.ToTable("STAFF_ATTACHMENT");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.Supplier", b =>
                {
                    b.Property<long>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SUPPLIER_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("ADDRESS")
                        .HasColumnType("varchar(max)");

                    b.Property<long>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnType("datetime");

                    b.Property<decimal>("CurrentBalance")
                        .HasColumnName("CURRENT_BALANCE")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CurrentStatus")
                        .HasColumnName("CURRENT_STATUS")
                        .HasColumnType("int");

                    b.Property<string>("Landline")
                        .HasColumnName("LANDLINE")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("Mobile")
                        .HasColumnName("MOBILE")
                        .HasColumnType("nchar(10)");

                    b.Property<decimal>("OpeningBalance")
                        .HasColumnName("OPENING_BALANCE")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("SupplierName")
                        .HasColumnName("SUPPLIER_NAME")
                        .HasColumnType("varchar(50)");

                    b.HasKey("SupplierId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("SUPPLIER");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.SupplierAttachment", b =>
                {
                    b.Property<long>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ATTACHMENT_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmentName")
                        .HasColumnName("ATTACHMENT_NAME")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("AttachmentPath")
                        .HasColumnName("ATTACHMENT_PATH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("MimeType")
                        .HasColumnName("MIME_TYPE")
                        .HasColumnType("varchar(200)");

                    b.Property<long>("SupplierId")
                        .HasColumnName("SUPPLIER_ID")
                        .HasColumnType("bigint");

                    b.HasKey("AttachmentId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SUPPLIER_ATTACHMENT");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.SupplierPayment", b =>
                {
                    b.Property<long>("SupplierPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SUPPLIER_PAYMENT_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cash")
                        .HasColumnName("CASH")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Cheque")
                        .HasColumnName("CHEQUE")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<long>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("varchar(100)");

                    b.Property<long>("PaymentType")
                        .HasColumnName("PAYMENT_TYPE")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Purchase")
                        .HasColumnName("PURCHASE")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Remark")
                        .HasColumnName("REMARK")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Returns")
                        .HasColumnName("RETURNS")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("int");

                    b.Property<long>("SupplierId")
                        .HasColumnName("SUPPLIER_ID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnName("TOTAL_AMOUNT")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("SupplierPaymentId");

                    b.HasIndex("PaymentType");

                    b.HasIndex("SupplierId");

                    b.ToTable("SUPPLIER_PAYMENT");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.SupplierPaymentOwnCheque", b =>
                {
                    b.Property<long>("OwnChequeId")
                        .HasColumnName("OWN_CHEQUE_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("SupplierPaymentId")
                        .HasColumnName("SUPPLIER_PAYMENT_ID")
                        .HasColumnType("bigint");

                    b.HasKey("OwnChequeId", "SupplierPaymentId");

                    b.HasIndex("SupplierPaymentId");

                    b.ToTable("SUPPLIER_PAYMENT_OWN_CHEQUE");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.ThirdPartyCheque", b =>
                {
                    b.Property<long>("ThirdPartyChequeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("THIRD_PARTY_CHEQUE_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("AMOUNT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Bank")
                        .HasColumnName("BANK")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Branch")
                        .HasColumnName("BRANCH")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("ChequeCode")
                        .HasColumnName("CHEQUE_CODE")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnName("DUE_DATE")
                        .HasColumnType("datetime");

                    b.Property<string>("From")
                        .HasColumnName("FROM")
                        .HasColumnType("varchar(70)");

                    b.Property<long?>("FromReferenceId")
                        .HasColumnName("FROM_REFERENCE_ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("FromReferenceNote")
                        .HasColumnName("FROM_REFERENCE_NOTE")
                        .HasColumnType("bigint");

                    b.Property<string>("Remark")
                        .HasColumnName("REMARK")
                        .HasColumnType("varchar(100)");

                    b.Property<long>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("bigint");

                    b.HasKey("ThirdPartyChequeId");

                    b.HasIndex("Status");

                    b.ToTable("THIRD_PARTY_CHEQUE");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.ThirdPartyChequeActionLog", b =>
                {
                    b.Property<long>("ThirdPartyChequeActionLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("THIRD_PARTY_CHEQUE_ACTION_LOG_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ChequeStatusId")
                        .HasColumnName("CHEQUE_STATUS_ID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("datetime");

                    b.Property<long?>("RecipientId")
                        .HasColumnName("RECIPIENT_ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReferenceId")
                        .HasColumnName("REFERENCE_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("ThirdPartyChequeId")
                        .HasColumnName("THIRD_PARTY_CHEQUE_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("bigint");

                    b.HasKey("ThirdPartyChequeActionLogId");

                    b.HasIndex("ChequeStatusId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("ThirdPartyChequeId");

                    b.HasIndex("UserId");

                    b.ToTable("THIRD_PARTY_CHEQUE_ACTION_LOG");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentStatus")
                        .HasColumnName("CURRENT_STATUS")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnName("PASSWORD")
                        .HasColumnType("varchar(50)");

                    b.Property<long>("StaffId")
                        .HasColumnName("STAFF_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasColumnName("USERNAME")
                        .HasColumnType("varchar(10)");

                    b.HasKey("UserId");

                    b.HasIndex("StaffId");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.Customer", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.CustomerAttachment", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.OwnCheque", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.ChequeStatus", "ChequeStatus")
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.OwnChequeActionLog", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.ChequeStatus", "ChequeStatus")
                        .WithMany()
                        .HasForeignKey("ChequeStatusId");

                    b.HasOne("Sharmila_Textile_WebApp.Models.OwnCheque", "OwnCheque")
                        .WithMany()
                        .HasForeignKey("OwnChequeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sharmila_Textile_WebApp.Models.Recipient", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("Sharmila_Textile_WebApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.StaffAttachment", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.Supplier", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.SupplierAttachment", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.SupplierPayment", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.ChequeStatus", "ChequeStatus")
                        .WithMany()
                        .HasForeignKey("PaymentType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sharmila_Textile_WebApp.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.SupplierPaymentOwnCheque", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.OwnCheque", "OwnCheque")
                        .WithMany("SupplierPaymentOwnCheques")
                        .HasForeignKey("OwnChequeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sharmila_Textile_WebApp.Models.SupplierPayment", "SupplierPayment")
                        .WithMany("SupplierPaymentOwnCheques")
                        .HasForeignKey("SupplierPaymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.ThirdPartyCheque", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.ChequeStatus", "ChequeStatus")
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.ThirdPartyChequeActionLog", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.ChequeStatus", "ChequeStatus")
                        .WithMany()
                        .HasForeignKey("ChequeStatusId");

                    b.HasOne("Sharmila_Textile_WebApp.Models.Recipient", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("Sharmila_Textile_WebApp.Models.ThirdPartyCheque", "ThirdPartyCheque")
                        .WithMany()
                        .HasForeignKey("ThirdPartyChequeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sharmila_Textile_WebApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sharmila_Textile_WebApp.Models.User", b =>
                {
                    b.HasOne("Sharmila_Textile_WebApp.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
