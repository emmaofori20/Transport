using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class RequestType
    {
        public RequestType()
        {
            RequestTypeCharges = new HashSet<RequestTypeCharge>();
            VehicleMaintenanceRequestItems = new HashSet<VehicleMaintenanceRequestItem>();
        }

        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }

        public virtual ICollection<RequestTypeCharge> RequestTypeCharges { get; set; }
        public virtual ICollection<VehicleMaintenanceRequestItem> VehicleMaintenanceRequestItems { get; set; }
    }
}
