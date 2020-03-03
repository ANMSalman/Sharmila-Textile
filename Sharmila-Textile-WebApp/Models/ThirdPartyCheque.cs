using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("THIRD_PARTY_CHEQUE")]
    public class ThirdPartyCheque {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("THIRD_PARTY_CHEQUE_ID")]
        public long ThirdPartyChequeId { get; set; }

        [Column("CHEQUE_CODE", TypeName = "varchar(50)")]
        public string ChequeCode { get; set; }

        [Column("BANK", TypeName = "varchar(70)")]
        public string Bank { get; set; }

        [Column("BRANCH", TypeName = "varchar(70)")]
        public string Branch { get; set; }

        [Column("AMOUNT", TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Column("DATE", TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Column("DUE_DATE", TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        [Column("REMARK", TypeName = "varchar(100)")]
        public string Remark { get; set; }

        [Column("STATUS")]
        public long Status { get; set; }

        [Column("FROM", TypeName = "varchar(70)")]
        public string From { get; set; }

        [Column("FROM_REFERENCE_ID")]
        public long? FromReferenceId { get; set; }

        [Column("FROM_REFERENCE_NOTE")]
        public long? FromReferenceNote { get; set; }

        [ForeignKey("Status")]
        public ChequeStatus ChequeStatus { get; set; }
        public List<SupplierPaymentThirdPartyCheque> SupplierPaymentThirdPartyCheques { get; set; }
        public List<CollectionThirdPartyCheque> CollectionThirdPartyCheques { get; set; }
        public List<CustomerAccountThirdPartyCheque> CustomerAccountThirdPartyCheques { get; set; }
        public List<SupplierAccountThirdPartyCheque> SupplierAccountThirdPartyCheques { get; set; }
        public List<ExpenseThirdPartyCheque> ExpenseThirdPartyCheques { get; set; }
        public List<BankDepositThirdPartyCheque> BankDepositThirdPartyCheques { get; set; }
    }
}
