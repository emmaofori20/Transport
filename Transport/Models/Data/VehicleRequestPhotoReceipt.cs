using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleRequestPhotoReceipt
    {
        public int VehicleRequestRecieptId { get; set; }
        public string ReceiptName { get; set; }
        public string ReceiptPhotoUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int VehicleMaintenanceRequestId { get; set; }

        public virtual VehicleMaintenanceRequest VehicleMaintenanceRequest { get; set; }
    }
}
