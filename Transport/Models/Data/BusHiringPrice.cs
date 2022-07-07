using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class BusHiringPrice
    {
        public int BusHiringPriceId { get; set; }
        public decimal? Price { get; set; }
        public int BusHiringDistanceId { get; set; }
        public int VehicleTypeForHire { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual BusHiringDistance BusHiringDistance { get; set; }
        public virtual VehicleTypeForHire VehicleTypeForHireNavigation { get; set; }
    }
}
