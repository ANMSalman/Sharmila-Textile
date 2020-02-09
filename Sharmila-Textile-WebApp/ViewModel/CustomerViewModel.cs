using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class CustomerViewModel {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string NIC { get; set; }
        public string HomeAddress { get; set; }
        public string HomeLandline { get; set; }
        public string OfficeAddress { get; set; }
        public string OfficeLandline { get; set; }
        public string Mobile { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public int CurrentStatus { get; set; } 
        public string UserName { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public List<CustomerAttachmentViewModel> CustomerAttachmentList { get; set; }
    }
}
