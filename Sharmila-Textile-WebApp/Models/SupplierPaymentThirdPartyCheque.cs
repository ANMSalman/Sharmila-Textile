using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE")]
    public class SupplierPaymentThirdPartyCheque {
        [Column("SUPPLIER_PAYMENT_ID")]
        public long SupplierPaymentId { get; set; }
        public SupplierPayment SupplierPayment { get; set; }

        [Column("THIRD_PARTY_CHEQUE_ID")]
        public long ThirdPartyChequeId { get; set; }
        public ThirdPartyCheque ThirdPartyCheque { get; set; }
    }
}
