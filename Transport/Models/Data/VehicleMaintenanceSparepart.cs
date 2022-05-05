using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleMaintenanceSparepart
    {
        public int VehicleMaitenanceSparepartId { get; set; }
        public int VehicleMaintenanceRequestId { get; set; }
        public string NameOfPart { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual VehicleMaintenanceRequest VehicleMaintenanceRequest { get; set; }
    }
}
