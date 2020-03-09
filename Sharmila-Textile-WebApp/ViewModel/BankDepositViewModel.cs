using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class BankDepositViewModel { 
        public long BankDepositId { get; set; } 
        public decimal Cash { get; set; } 
        public decimal InHandCash { get; set; } 
        public decimal TotalAmount { get; set; }
        public decimal ChequeTotal { get; set; } 
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; } 
        public long CreatedBy { get; set; }
        public string UserName { get; set; }  
        public List<ThirdPartyCheque> ThirdPartyChequesList { get; set; }
        public List<long> ThirdPartyChequesId { get; set; }

    }
}
