using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class SupplierPaymentViewModel {
        public long SupplierPaymentId { get; set; } 
        public string Description { get; set; } 
        public decimal Cash { get; set; }
        public decimal InHandCash { get; set; }
        public decimal Cheque { get; set; } 
        public decimal Returns { get; set; } 
        public decimal Purchase { get; set; } 
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public long PaymentType { get; set; } 
        public string PaymentTypeName { get; set; } 
        public long SupplierId { get; set; } 
        public string SupplierName { get; set; } 
        public long CreatedBy { get; set; } 
        public string UserName { get; set; } 
        public string Remark { get; set; }
        public List<Supplier> SupplierList { get; set; }
        public List<ChequeStatusViewModel> PaymentTypeList { get; set; }
        public List<OwnCheque> OwnChequesList { get; set; }
        public List<ThirdPartyCheque> ThirdPartyChequesList { get; set; }
        public List<long> OwnChequesId { get; set; }
        public List<long> ThirdPartyChequesId { get; set; }
    }
}
