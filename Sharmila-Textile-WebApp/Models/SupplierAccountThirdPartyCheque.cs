using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE")]
    public class SupplierAccountThirdPartyCheque {
        [Column("SUPPLIER_ACCOUNTS_ID")]
        public long SupplierAccountId { get; set; }
        public SupplierAccount SupplierAccount { get; set; }

        [Column("THIRD_PARTY_CHEQUE_ID")]
        public long ThirdPartyChequeId { get; set; }
        public ThirdPartyCheque ThirdPartyCheque { get; set; }
    }
}
