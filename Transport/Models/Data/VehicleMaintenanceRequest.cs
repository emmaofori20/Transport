using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleMaintenanceRequest
    {
        public VehicleMaintenanceRequest()
        {
            VehicleMaintenanceRequestItems = new HashSet<VehicleMaintenanceRequestItem>();
            VehicleMaintenanceRequestStatuses = new HashSet<VehicleMaintenanceRequestStatus>();
            VehicleRequestPhotoReceipts = new HashSet<VehicleRequestPhotoReceipt>();
        }

        public int VehicleMaintenanceRequestId { get; set; }
        public int VehicleId { get; set; }
        public string MaintenanceDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<VehicleMaintenanceRequestItem> VehicleMaintenanceRequestItems { get; set; }
        public virtual ICollection<VehicleMaintenanceRequestStatus> VehicleMaintenanceRequestStatuses { get; set; }
        public virtual ICollection<VehicleRequestPhotoReceipt> VehicleRequestPhotoReceipts { get; set; }
    }
}
