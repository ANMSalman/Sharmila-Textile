using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("CUSTOMER_ACCOUNT")]
    public class CustomerAccount {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CUSTOMER_ACCOUNTS_ID")]
        public long CustomerAccountId { get; set; }

        [Column("DESCRIPTION", TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Column("AMOUNT", TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Column("IN_HAND_CASH", TypeName = "decimal(18, 2)")]
        public decimal InHandCash { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("ACCOUNT_TYPE")]
        public string AccountType { get; set; }

        [Column("CUSTOMER_ID")]
        public long CustomerId { get; set; }

        [Column("CREATED_BY")]
        public long CreatedBy { get; set; }

        [Column("REMARK", TypeName = "varchar(100)")]
        public string Remark { get; set; }

        [Column("STATUS")]
        public int Status { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("CreatedBy")]
        public User User { get; set; }

        public List<CustomerAccountOwnCheque> CustomerAccountOwnCheques { get; set; }
        public List<CustomerAccountThirdPartyCheque> CustomerAccountThirdPartyCheques { get; set; }
    }
}
