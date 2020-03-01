using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("BANK_DEPOSIT_THIRD_PARTY_CHEQUE")]
    public class BankDepositThirdPartyCheque {
        [Column("BANK_DEPOSIT_ID")]
        public long BankDepositId { get; set; }
        public BankDeposit BankDeposit { get; set; }

        [Column("THIRD_PARTY_CHEQUE_ID")]
        public long ThirdPartyChequeId { get; set; }
        public ThirdPartyCheque ThirdPartyCheque { get; set; }
    }
}
