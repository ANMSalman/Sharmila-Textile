using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.Models {
    [Table("COLLECTION_OWN_CHEQUE")] 
    public class CollectionOwnCheque {

        [Column("COLLECTION_ID")]
        public long CollectionId { get; set; }
        public Collection Collection { get; set; }

        [Column("OWN_CHEQUE_ID")]
        public long OwnChequeId { get; set; }
        public OwnCheque OwnCheque { get; set; }

    }
}
