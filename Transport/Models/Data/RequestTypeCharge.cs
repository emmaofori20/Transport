using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class RequestTypeCharge
    {
        public RequestTypeCharge()
        {
            VehicleMaintenanceRequestItems = new HashSet<VehicleMaintenanceRequestItem>();
        }

        public int RequestTypeChargeId { get; set; }
        public int RequestTypeId { get; set; }
        public string ChargeName { get; set; }
        public decimal ChargeValue { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }

        public virtual RequestType RequestType { get; set; }
        public virtual ICollection<VehicleMaintenanceRequestItem> VehicleMaintenanceRequestItems { get; set; }
    }
}
