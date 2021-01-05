using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class ItemOrder
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemOrder()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemOrderId { get; set; }

        public int OrderId { get; set; }
        public int ItemId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}
