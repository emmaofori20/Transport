using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleMaintenanceRequest
    {
        public VehicleMaintenanceRequest()
        {
            VehicleMaintenanceRequestStatuses = new HashSet<VehicleMaintenanceRequestStatus>();
            VehicleMaintenanceSpareparts = new HashSet<VehicleMaintenanceSparepart>();
        }

        public int VehicleMaintenanceRequestId { get; set; }
        public int VehicleId { get; set; }
        public decimal MainteinanceCost { get; set; }
        public string MaintenanceDescription { get; set; }
        public string MaintainedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<VehicleMaintenanceRequestStatus> VehicleMaintenanceRequestStatuses { get; set; }
        public virtual ICollection<VehicleMaintenanceSparepart> VehicleMaintenanceSpareparts { get; set; }
    }
}
