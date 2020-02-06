using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
 
namespace Sharmila_Textile_WebApp.Models {
    [Table("SUPPLIER")]
    public class Supplier {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SUPPLIER_ID")]
        public long SupplierId { get; set; }

        [Column("SUPPLIER_NAME", TypeName = "varchar(50)")]
        public string SupplierName { get; set; }

        [Column("ADDRESS", TypeName = "varchar(max)")]
        public string Address { get; set; }

        [Column("LANDLINE", TypeName = "nchar(10)")]
        public string Landline { get; set; }

        [Column("MOBILE", TypeName = "nchar(10)")]
        public string Mobile { get; set; }

        [Column("OPENING_BALANCE", TypeName = "decimal(18, 2)")]
        public double OpeningBalance { get; set; }

        [Column("CURRENT_BALANCE", TypeName = "decimal(18, 2)")]
        public double CurrentBalance { get; set; }

        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Column("CREATED_BY")]
        public long CreatedBy { get; set; }

        [Column("CURRENT_STATUS", TypeName = "int")]
        public int CurrentStatus { get; set; }

        [ForeignKey("CreatedBy")]
        public User User { get; set; }
    }
}
