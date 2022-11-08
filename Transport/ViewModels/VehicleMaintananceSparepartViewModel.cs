using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class VehicleMaintananceSparepartViewModel
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string SparePartName { get; set; }
        [Required]
        public double Amount { get; set; }
        public int RequestTypeId { get; set; }
        public decimal RequestChargeValue { get; set; }
        public string RequestChargeName { get; set; }
    }
}
