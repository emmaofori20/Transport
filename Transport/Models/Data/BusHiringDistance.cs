using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class BusHiringDistance
    {
        public BusHiringDistance()
        {
            BusHiringPrices = new HashSet<BusHiringPrice>();
        }

        public int BusHiringDistanceId { get; set; }
        public int MinimumDistance { get; set; }
        public int? MaximumDistance { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<BusHiringPrice> BusHiringPrices { get; set; }
    }
}
