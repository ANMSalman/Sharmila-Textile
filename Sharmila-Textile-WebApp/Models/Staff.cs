using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {

    [Table("STAFF")]
    public class Staff {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("STAFF_ID")]
        public long StaffId { get; set; }
        
        [Column("STAFF_NAME", TypeName = "varchar(50)")] 
        public string StaffName { get; set; }
         
        [Column("NIC", TypeName = "varchar(12)")]
        public string Nic { get; set; }

        [Column("ADDRESS", TypeName = "varchar(max)")]
        public string Address { get; set; }
        
        [Column("CONTACT_NO", TypeName = "varchar(10)")]
        public string ContactNo { get; set; }

        [DefaultValue(1)]
        [Column("CURRENT_STATUS", TypeName = "int")]
        public int CurrentStatus { get; set; }

    }
}
