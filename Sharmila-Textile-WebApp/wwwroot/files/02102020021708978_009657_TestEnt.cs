using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace SharmilaTex.Models { 
    public class TestEnt {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("STAFF_ID")]
        public long StaffId { get; set; }

        [StringLength(50, ErrorMessage = "Staff Name must not be longer than 50 characters")]
        [Column("STAFF_NAME")]
        public string StaffName { get; set; }
         
        [Column("NIC", TypeName = "varchar(max)")]
        public string Nic { get; set; }
    }
}
