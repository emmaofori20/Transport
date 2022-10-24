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
        public bool? IsDeleted { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<RequestTypeCharge> RequestTypeCharges { get; set; }
        public virtual ICollection<VehicleMaintenanceRequestItem> VehicleMaintenanceRequestItems { get; set; }
    }
}
