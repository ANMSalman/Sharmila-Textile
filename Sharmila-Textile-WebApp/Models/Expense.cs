using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("EXPENSE")]
    public class Expense {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EXPENSE_ID")]
        public long ExpenseId { get; set; }

        [Column("DESCRIPTION", TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Column("CASH", TypeName = "decimal(18, 2)")]
        public decimal Cash { get; set; }

        [Column("IN_HAND_CASH", TypeName = "decimal(18, 2)")]
        public decimal InHandCash { get; set; }

        [Column("CHEQUE", TypeName = "decimal(18, 2)")]
        public decimal Cheque { get; set; }

        [Column("TOTAL_AMOUNT", TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("PAYMENT_TYPE", TypeName = "varchar(50)")]
        public string PaymentType { get; set; }

        [Column("CREATED_BY")]
        public long CreatedBy { get; set; }

        [Column("REMARK", TypeName = "varchar(100)")]
        public string Remark { get; set; }

        [Column("STATUS")]
        public int Status { get; set; }  

        [ForeignKey("CreatedBy")]
        public User User { get; set; }

        public List<ExpenseOwnCheque> ExpenseOwnCheques { get; set; }
        public List<ExpenseThirdPartyCheque> ExpenseThirdPartyCheques { get; set; }  

    }
}
