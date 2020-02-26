using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("OWN_CHEQUE")]
    public class OwnCheque {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OWN_CHEQUE_ID")]
        public long OwnChequeId { get; set; }

        [Column("CHEQUE_CODE", TypeName = "varchar(50)")]
        public string ChequeCode { get; set; }

        [Column("BANK", TypeName = "varchar(70)")]
        public string Bank { get; set; }

        [Column("BRANCH", TypeName = "varchar(70)")]
        public string Branch { get; set; }

        [Column("AMOUNT", TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Column("DUE_DATE", TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        [Column("REMARK", TypeName = "varchar(100)")]
        public string Remark { get; set; }

        [Column("STATUS")]
        public long Status { get; set; }

        [ForeignKey("Status")]
        public ChequeStatus ChequeStatus { get; set; }

        public List<SupplierPaymentOwnCheque> SupplierPaymentOwnCheques { get; set; }
        public List<CollectionOwnCheque> CollectionOwnCheques { get; set; }
    }
}
