using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleMaintenanceRequestStatus
    {
        public int VehicleMaintenanceRequestStatusId { get; set; }
        public int VehicleMaintenanceRequestId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int MaintenanceStatusId { get; set; }

        public virtual MaintenanceStatus MaintenanceStatus { get; set; }
        public virtual VehicleMaintenanceRequest VehicleMaintenanceRequest { get; set; }
    }
}
