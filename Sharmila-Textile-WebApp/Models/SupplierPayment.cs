using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("SUPPLIER_PAYMENT")]
    public class SupplierPayment {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SUPPLIER_PAYMENT_ID")]
        public long SupplierPaymentId { get; set; }

        [Column("DESCRIPTION", TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Column("CASH", TypeName = "decimal(18, 2)")]
        public decimal Cash { get; set; }

        [Column("CHEQUE", TypeName = "decimal(18, 2)")]
        public decimal Cheque { get; set; }

        [Column("RETURNS", TypeName = "decimal(18, 2)")]
        public decimal Returns { get; set; }

        [Column("PURCHASE", TypeName = "decimal(18, 2)")]
        public decimal Purchase { get; set; }

        [Column("TOTAL_AMOUNT", TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("PAYMENT_TYPE")]
        public long PaymentType { get; set; }

        [Column("SUPPLIER_ID")]
        public long SupplierId { get; set; }

        [Column("CREATED_BY")]
        public long CreatedBy { get; set; }

        [Column("REMARK", TypeName = "varchar(100)")]
        public string Remark { get; set; }

        [Column("STATUS")]
        public int Status { get; set; }

        public Supplier Supplier { get; set; }

        [ForeignKey("PaymentType")]
        public ChequeStatus ChequeStatus { get; set; }

        [ForeignKey("CreatedBy")]
        public User User { get; set; }
        public List<SupplierPaymentOwnCheque> SupplierPaymentOwnCheques { get; set; }
        public List<SupplierPaymentThirdPartyCheque> SupplierPaymentThirdPartyCheques { get; set; }
    }
}
