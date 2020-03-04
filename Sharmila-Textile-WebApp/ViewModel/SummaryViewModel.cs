using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class SummaryViewModel {
        public long SummaryId { get; set; }
        public decimal BttBills { get; set; }
        public decimal NormalBills { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalCollection { get; set; }
        public decimal AccountableCollection { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal AccountablePayment { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal AccountableExpense { get; set; }
        public decimal TotalBankDeposit { get; set; }
        public decimal AccountableBankDeposit { get; set; }
        public decimal SummaryTotal { get; set; }
        public decimal CashBalance { get; set; }
        public decimal ChequeBalance { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
