using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class BusHiringPriceViewModel
    {
        public int? BusHirngPriceId { get; set; }
        public decimal? Price { get; set; }
        public int BusHiringDistanceId { get; set; }
        public int VehicleTypeForHireId { get; set; }
    }
}
