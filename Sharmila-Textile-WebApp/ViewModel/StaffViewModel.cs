using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class StaffViewModel {
        public long StaffId { get; set; }
        public string StaffName { get; set; }
        public string Nic { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public List<StaffAttachmentViewModel> StaffAttachmentList { get; set; }
    }
}
