using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("THIRD_PARTY_CHEQUE_ACTION_LOG")]
    public class ThirdPartyChequeActionLog {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("THIRD_PARTY_CHEQUE_ACTION_LOG_ID")]
        public long ThirdPartyChequeActionLogId { get; set; }

        [Column("CREATED_DATE", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("THIRD_PARTY_CHEQUE_ID")]
        public long ThirdPartyChequeId { get; set; }

        [Column("REFERENCE_ID")]
        public long? ReferenceId { get; set; }

        [Column("RECIPIENT_ID")]
        public long? RecipientId { get; set; }

        [Column("CHEQUE_STATUS_ID")]
        public long? ChequeStatusId { get; set; }

        [Column("USER_ID")]
        public long UserId { get; set; }
         
        public Recipient Recipient { get; set; }
        public ChequeStatus ChequeStatus { get; set; }
        public ThirdPartyCheque ThirdPartyCheque { get; set; }
        public User User { get; set; }
    }
}
