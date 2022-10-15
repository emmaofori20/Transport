using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class HiringTableMatrixViewModel
    {
        public List<VehicleTypeForHire> VehicleTypeForHires { get; set; }
        public List<BusHiringDistance> BusHiringDistances { get; set; }
        public List<BusHiringPriceViewModel> BusPricesForDistanceAndVehicleType { get; set; }
        public List<BusHiringPrice> BusHiringPrices { get; set; }
        public List<decimal> Prices { get; set; }
    }
}
