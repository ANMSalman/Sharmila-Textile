using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("EXPENSE_OWN_CHEQUE")]
    public class ExpenseOwnCheque {
        [Column("EXPENSE_ID")]
        public long ExpenseId { get; set; }
        public Expense Expense { get; set; }

        [Column("OWN_CHEQUE_ID")]
        public long OwnChequeId { get; set; }
        public OwnCheque OwnCheque { get; set; }
    }
}
