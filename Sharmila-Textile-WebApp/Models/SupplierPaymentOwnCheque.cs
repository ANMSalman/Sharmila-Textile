using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("SUPPLIER_PAYMENT_OWN_CHEQUE")]
    public class SupplierPaymentOwnCheque {

        [Column("SUPPLIER_PAYMENT_ID")]
        public long SupplierPaymentId { get; set; }
        public SupplierPayment SupplierPayment { get; set; }

        [Column("OWN_CHEQUE_ID")]
        public long OwnChequeId { get; set; }
        public OwnCheque OwnCheque { get; set; }
    }
}
