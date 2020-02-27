using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE")]
    public class CustomerAccountThirdPartyCheque {
        [Column("CUSTOMER_ACCOUNTS_ID")]
        public long CustomerAccountId { get; set; }
        public CustomerAccount CustomerAccount { get; set; }

        [Column("THIRD_PARTY_CHEQUE_ID")]
        public long ThirdPartyChequeId { get; set; }
        public ThirdPartyCheque ThirdPartyCheque { get; set; }
    }
}
