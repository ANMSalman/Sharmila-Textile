using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("COLLECTION_THIRD_PARTY_CHEQUE")]
    public class CollectionThirdPartyCheque {

        [Column("COLLECTION_ID")]
        public long CollectionId { get; set; }
        public Collection Collection { get; set; }

        [Column("THIRD_PARTY_CHEQUE_ID")]
        public long ThirdPartyChequeId { get; set; }
        public ThirdPartyCheque ThirdPartyCheque { get; set; }

    }
}
