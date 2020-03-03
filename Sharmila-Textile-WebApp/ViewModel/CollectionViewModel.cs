using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class CollectionViewModel {
        public long CollectionId { get; set; } 
        public string Description { get; set; } 
        public decimal Cash { get; set; } 
        public decimal Cheque { get; set; } 
        public decimal Returns { get; set; }  
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CollectionType { get; set; } 
        public string CollectionTypeName { get; set; } 
        public long CustomerId { get; set; } 
        public string CustomerName { get; set; } 
        public long CreatedBy { get; set; } 
        public string UserName { get; set; } 
        public string Remark { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<ChequeStatusViewModel> CollectionTypeList { get; set; }
        public List<OwnCheque> OwnChequesList { get; set; }
        public List<ThirdPartyCheque> ThirdPartyChequesList { get; set; }
        public List<long> OwnChequesId { get; set; }
        public List<long> ThirdPartyChequesId { get; set; }
    }
}
