using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("OWN_CHEQUE_ACTION_LOG")]
    public class OwnChequeActionLog {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OWN_CHEQUE_ACTION_LOG_ID")]
        public long OwnChequeActionLogId { get; set; }

        [Column("CREATED_DATE", TypeName = "datetime")] 
        public DateTime CreatedDate { get; set; }

        [Column("OWN_CHEQUE_ID")]
        public long OwnChequeId { get; set; }

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
        public OwnCheque OwnCheque { get; set; }
        public User User { get; set; }

    }
}
