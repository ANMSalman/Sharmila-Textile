using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("USER")]
    public class User {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("USER_ID")]
        public long UserId { get; set; }

        [Column("USERNAME", TypeName = "varchar(10)")]
        public string UserName { get; set; }

        [Column("PASSWORD", TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Column("CURRENT_STATUS", TypeName = "int")]
        public int CurrentStatus { get; set; }

        [Column("STAFF_ID")]
        public long StaffId { get; set; }

        public Staff Staff { get; set; }
    }
}
