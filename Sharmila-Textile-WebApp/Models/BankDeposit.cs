using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("BANK_DEPOSIT")]
    public class BankDeposit {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BANK_DEPOSIT_ID")]
        public long BankDepositId { get; set; }

        [Column("CASH", TypeName = "decimal(18, 2)")]
        public decimal Cash { get; set; }

        [Column("IN_HAND_CASH", TypeName = "decimal(18, 2)")]
        public decimal InHandCash { get; set; }

        [Column("TOTAL_AMOUNT", TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("CREATED_BY")]
        public long CreatedBy { get; set; }

        [Column("STATUS")]
        public int Status { get; set; }

        [ForeignKey("CreatedBy")]
        public User User { get; set; }

        public List<BankDepositThirdPartyCheque> BankDepositThirdPartyCheques { get; set; }

    }
}
