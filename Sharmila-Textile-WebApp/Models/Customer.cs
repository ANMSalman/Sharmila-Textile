using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("CUSTOMER")]
    public class Customer {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CUSTOMER_ID")]
        public long CustomerId { get; set; }

        [Column("CUSTOMER_NAME", TypeName = "varchar(50)")]
        public string CustomerName { get; set; }

        [Column("NIC", TypeName = "nchar(10)")]
        public string NIC { get; set; }

        [Column("HOME_ADDRESS", TypeName = "varchar(max)")]
        public string HomeAddress { get; set; }

        [Column("HOME_LAND_LINE", TypeName = "nchar(10)")]
        public string HomeLandline { get; set; }

        [Column("OFFICE_ADDRESS", TypeName = "varchar(max)")]
        public string OfficeAddress { get; set; }

        [Column("OFFICE_LAND_LINE", TypeName = "nchar(10)")]
        public string OfficeLandline { get; set; }

        [Column("MOBILE", TypeName = "nchar(10)")]
        public string Mobile { get; set; }

        [Column("OPENING_BALANCE", TypeName = "decimal(18, 2)")]
        public decimal OpeningBalance { get; set; }

        [Column("CURRENT_BALANCE", TypeName = "decimal(18, 2)")]
        public decimal CurrentBalance { get; set; }

        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Column("CREATED_BY")]
        public long CreatedBy { get; set; }

        [Column("CURRENT_STATUS", TypeName = "int")]
        public int CurrentStatus { get; set; }

        [ForeignKey("CreatedBy")]
        public User User { get; set; }

        [Column("LAST_COLLECTION_DATE", TypeName = "date")]
        public DateTime LastCollectionDate { get; set; }

    }
}
