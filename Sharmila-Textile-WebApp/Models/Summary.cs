using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("SUMMARY")]
    public class Summary {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SUMMARY_ID")]
        public long SummaryId { get; set; }

        [Column("BTT_BILLS", TypeName = "decimal(18, 2)")]
        public decimal BttBills { get; set; }

        [Column("NORMAL_BILLS", TypeName = "decimal(18, 2)")]
        public decimal NormalBills { get; set; }

        [Column("TOTAL_AMOUNT", TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Column("TOTAL_COLLECTION", TypeName = "decimal(18, 2)")]
        public decimal TotalCollection { get; set; }

        [Column("ACCOUNTABLE_COLLECTION", TypeName = "decimal(18, 2)")]
        public decimal AccountableCollection { get; set; }

        [Column("TOTAL_PAYMENT", TypeName = "decimal(18, 2)")]
        public decimal TotalPayment { get; set; }

        [Column("ACCOUNTABLE_PAYMENT", TypeName = "decimal(18, 2)")]
        public decimal AccountablePayment { get; set; }

        [Column("TOTAL_EXPENSE", TypeName = "decimal(18, 2)")]
        public decimal TotalExpense { get; set; }

        [Column("ACCOUNTABLE_EXPENSE", TypeName = "decimal(18, 2)")]
        public decimal AccountableExpense { get; set; }

        [Column("TOTAL_BANK_DEPOSIT", TypeName = "decimal(18, 2)")]
        public decimal TotalBankDeposit { get; set; }

        [Column("ACCOUNTABLE_BANK_DEPOSIT", TypeName = "decimal(18, 2)")]
        public decimal AccountableBankDeposit { get; set; }

        [Column("TOTAL_CUSTOMER_ACCOUNT", TypeName = "decimal(18, 2)")]
        public decimal TotalCustomerAccount { get; set; }

        [Column("ACCOUNTABLE_CUSTOMER_ACCOUNT", TypeName = "decimal(18, 2)")]
        public decimal AccountableCustomerAccount { get; set; }

        [Column("TOTAL_SUPPLIER_ACCOUNT", TypeName = "decimal(18, 2)")]
        public decimal TotalSupplierAccount { get; set; }

        [Column("ACCOUNTABLE_SUPPLIER_ACCOUNT", TypeName = "decimal(18, 2)")]
        public decimal AccountableSupplierAccount { get; set; }

        [Column("SUMMARY_TOTAL", TypeName = "decimal(18, 2)")]
        public decimal SummaryTotal { get; set; }

        [Column("CASH_BALANCE", TypeName = "decimal(18, 2)")]
        public decimal CashBalance { get; set; }

        [Column("CHEQUE_BALANCE", TypeName = "decimal(18, 2)")]
        public decimal ChequeBalance { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("STATUS")]
        public int Status { get; set; }
    }
}
