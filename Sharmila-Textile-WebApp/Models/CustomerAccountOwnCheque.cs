using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("CUSTOMER_ACCOUNT_OWN_CHEQUE")]
    public class CustomerAccountOwnCheque {
        [Column("CUSTOMER_ACCOUNTS_ID")]
        public long CustomerAccountId { get; set; }
        public CustomerAccount CustomerAccount { get; set; }

        [Column("OWN_CHEQUE_ID")]
        public long OwnChequeId { get; set; }
        public OwnCheque OwnCheque { get; set; }
    }
}
