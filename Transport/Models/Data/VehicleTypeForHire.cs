using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleTypeForHire
    {
        public VehicleTypeForHire()
        {
            BusHiringPrices = new HashSet<BusHiringPrice>();
            Hirers = new HashSet<Hirer>();
        }

        public int VehicleTypeForHireId { get; set; }
        public string VehicleType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<BusHiringPrice> BusHiringPrices { get; set; }
        public virtual ICollection<Hirer> Hirers { get; set; }
    }
}
