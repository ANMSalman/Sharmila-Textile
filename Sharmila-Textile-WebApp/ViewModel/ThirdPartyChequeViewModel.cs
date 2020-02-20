using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class ThirdPartyChequeViewModel {
        public long ThirdPartyChequeId { get; set; }
        public string ChequeCode { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Remark { get; set; }
        public long StatusId { get; set; }
        public string Status { get; set; } 
        public string From { get; set; } 
        public long? FromReferenceId { get; set; } 
        public long? FromReferenceNote { get; set; }
        public List<ChequeStatusViewModel> ChequeStatusesVm { get; set; }
        public ThirdPartyChequeActionLog ActionLog { get; set; }
        public List<string> BankList { get; set; }
        public List<string> BranchList { get; set; } 
        public List<Customer> CustomerList { get; set; }
        public List<Supplier> SupplierList { get; set; }
        public bool IsUpdate { get; set; } = true;
    }
}
