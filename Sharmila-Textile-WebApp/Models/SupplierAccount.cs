using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("SUPPLIER_ACCOUNT")] 
    public class SupplierAccount {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SUPPLIER_ACCOUNTS_ID")]
        public long SupplierAccountId { get; set; }

        [Column("DESCRIPTION", TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Column("AMOUNT", TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        [Column("ACCOUNT_TYPE")]
        public string AccountType { get; set; }

        [Column("SUPPLIER_ID")]
        public long SupplierId { get; set; }

        [Column("CREATED_BY")]
        public long CreatedBy { get; set; }

        [Column("REMARK", TypeName = "varchar(100)")]
        public string Remark { get; set; }

        [Column("STATUS")]
        public int Status { get; set; }

        public Supplier Supplier { get; set; }

        [ForeignKey("CreatedBy")]
        public User User { get; set; }

        public List<SupplierAccountOwnCheque> SupplierAccountOwnCheques { get; set; }
        public List<SupplierAccountThirdPartyCheque> SupplierAccountThirdPartyCheques { get; set; }
    }
}
