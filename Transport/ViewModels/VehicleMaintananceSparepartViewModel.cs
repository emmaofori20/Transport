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
    }
}
