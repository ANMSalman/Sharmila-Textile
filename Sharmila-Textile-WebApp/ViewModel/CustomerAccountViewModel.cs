using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class CustomerAccountViewModel {
        public long CustomerAccountId { get; set; } 
        public string Description { get; set; } 
        public decimal Amount { get; set; } 
        public decimal InHandCash { get; set; }  
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string AccountType { get; set; } 
        public long CustomerId { get; set; }
        public string Remark { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public long CreatedBy { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<OwnCheque> OwnChequesList { get; set; }
        public List<ThirdPartyCheque> ThirdPartyChequesList { get; set; }
        public List<long> OwnChequesId { get; set; }
        public List<long> ThirdPartyChequesId { get; set; }
    }
}
