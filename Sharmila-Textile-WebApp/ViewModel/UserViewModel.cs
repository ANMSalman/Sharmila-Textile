using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.ViewModel {
    public class UserViewModel {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int CurrentStatus { get; set; }

        public long StaffId { get; set; }
         
    }
}
