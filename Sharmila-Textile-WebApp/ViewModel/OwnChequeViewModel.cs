using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class OwnChequeViewModel {
        public long OwnChequeId { get; set; }
        public string ChequeCode { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string Remark { get; set; }
        public long StatusId { get; set; } 
        public string Status { get; set; } 
        public List<ChequeStatusViewModel> ChequeStatusesVm { get; set; } 
        public OwnChequeActionLog ActionLog { get; set; } 
        public List<string> BankList { get; set; } 
        public List<string> BranchList { get; set; }
        public bool IsUpdate { get; set; } = true;
    }
}
