using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.Models;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class StaffAttachmentViewModel {
        public long AttachmentId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentRandomName { get; set; }
        public string AttachmentFile { get; set; }
        public long StaffId { get; set; }

    }
}
