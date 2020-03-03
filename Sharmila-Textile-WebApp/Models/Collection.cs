using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("COLLECTION")] 
    public class Collection {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("COLLECTION_ID")]
        public long CollectionId { get; set; }

        [Column("DESCRIPTION", TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Column("CASH", TypeName = "decimal(18, 2)")]
        public decimal Cash { get; set; } 

        [Column("CHEQUE", TypeName = "decimal(18, 2)")]
        public decimal Cheque { get; set; }

        [Column("RETURNS", TypeName = "decimal(18, 2)")]
        public decimal Returns { get; set; }

        [Column("TOTAL_AMOUNT", TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("COLLECTION_TYPE")]
        public long CollectionType { get; set; }

        [Column("CUSTOMER_ID")]
        public long CustomerId { get; set; }

        [Column("CREATED_BY")]
        public long CreatedBy { get; set; }

        [Column("REMARK", TypeName = "varchar(100)")]
        public string Remark { get; set; }

        [Column("STATUS")]
        public int Status { get; set; }

        [ForeignKey("CollectionType")]
        public ChequeStatus ChequeStatus { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("CreatedBy")]
        public User User { get; set; }

        public List<CollectionOwnCheque> CollectionOwnCheques { get; set; }
        public List<CollectionThirdPartyCheque> CollectionThirdPartyCheques { get; set; }

    }
}
