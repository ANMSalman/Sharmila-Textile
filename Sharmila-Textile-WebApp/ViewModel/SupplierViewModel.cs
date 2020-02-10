using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class SupplierViewModel {
        public long SupplierId { get; set; } 
        public string SupplierName { get; set; } 
        public string Address { get; set; } 
        public string Landline { get; set; } 
        public string Mobile { get; set; } 
        public decimal OpeningBalance { get; set; } 
        public decimal CurrentBalance { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public long CreatedBy { get; set; } 
        public int CurrentStatus { get; set; }
        public string UserName { get; set; }
        public List<SupplierAttachmentViewModel> SupplierAttachmentList { get; set; }
    }
}
