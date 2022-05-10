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
        public int VehicleMaintenanceRequestId { get; set; }

        public virtual VehicleMaintenanceRequest VehicleMaintenanceRequest { get; set; }
    }
}
