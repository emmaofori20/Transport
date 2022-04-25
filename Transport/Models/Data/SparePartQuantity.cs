using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class SparePartQuantity
    {
        public int SparePartQuantityId { get; set; }
        public int SparePartId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual SparePart SparePart { get; set; }
    }
}
