using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class CustomerAttachmentViewModel {
        public long AttachmentId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentRandomName { get; set; }
        public string AttachmentFile { get; set; }
        public long CustomerId { get; set; }
    }
}
