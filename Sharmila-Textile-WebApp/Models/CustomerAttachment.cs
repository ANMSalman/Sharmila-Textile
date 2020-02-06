using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("CUSTOMER_ATTACHMENT")]

    public class CustomerAttachment {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ATTACHMENT_ID")]
        public long AttachmentId { get; set; }

        [Column("ATTACHMENT_NAME", TypeName = "varchar(max)")]
        public string AttachmentName { get; set; }

        [Column("ATTACHMENT_PATH", TypeName = "varchar(max)")]
        public string AttachmentPath { get; set; }

        [Column("CUSTOMER_ID")]
        public long CustomerId { get; set; }

        public Customer Customer { get; set; }

    }
}
