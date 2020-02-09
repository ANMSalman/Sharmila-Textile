using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("STAFF_ATTACHMENT")]

    public class StaffAttachment {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ATTACHMENT_ID")]
        public long AttachmentId { get; set; }

        [Column("ATTACHMENT_NAME", TypeName = "varchar(max)")]
        public string AttachmentName { get; set; }

        [Column("ATTACHMENT_PATH", TypeName = "varchar(max)")]
        public string AttachmentPath { get; set; }

        [Column("MIME_TYPE", TypeName = "varchar(50)")]
        public string MimeType { get; set; }

        [Column("STAFF_ID")]
        public long StaffId { get; set; }

        public Staff Staff { get; set; }

    }
}
