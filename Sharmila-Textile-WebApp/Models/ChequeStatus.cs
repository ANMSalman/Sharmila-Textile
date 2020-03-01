using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("CHEQUE_STATUS")] 
    public class ChequeStatus {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CHEQUE_STATUS_ID")]
        public long ChequeStatusId { get; set; }

        [Column("STATUS_NAME", TypeName = "varchar(50)")]
        public string StatusName { get; set; }

        [Column("STATUS_TYPE", TypeName = "varchar(10)")]
        public string StatusType { get; set; }
    }
}
