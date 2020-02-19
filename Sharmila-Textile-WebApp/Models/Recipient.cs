using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("RECIPIENT")]
    public class Recipient {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RECIPIENT_ID")]
        public long RecipientId { get; set; }

        [Column("RECIPIENT_TYPE", TypeName = "varchar(70)")]
        public string RecipientType { get; set; }
    }
}
