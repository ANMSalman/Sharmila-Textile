using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models { 
    [Table("BALANCE_SHEET")]
    public class BalanceSheet {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BALANCE_SHEET_ID")]
        public long BalanceSheetId { get; set; }

        [Column("IN_HAND_CASH", TypeName = "decimal(18, 2)")]
        public decimal InHandCash { get; set; }

        [Column("IN_HAND_CHEQUE", TypeName = "decimal(18, 2)")]
        public decimal InHandCheque { get; set; }

        [Column("BANK_BALANCE", TypeName = "decimal(18, 2)")]
        public decimal BankBalance { get; set; }

        [Column("IN_HOLD", TypeName = "decimal(18, 2)")]
        public decimal InHold { get; set; }

    }
}
