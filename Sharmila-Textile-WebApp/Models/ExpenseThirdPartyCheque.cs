using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("EXPENSE_THIRD_PARTY_CHEQUE")]
    public class ExpenseThirdPartyCheque {
        [Column("EXPENSE_ID")]
        public long ExpenseId { get; set; }
        public Expense Expense { get; set; }

        [Column("THIRD_PARTY_CHEQUE_ID")]
        public long ThirdPartyChequeId { get; set; }
        public ThirdPartyCheque ThirdPartyCheque { get; set; }
    }
}
