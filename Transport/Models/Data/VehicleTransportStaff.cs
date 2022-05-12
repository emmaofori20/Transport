using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleTransportStaff
    {
        public int VehicleTransportStaffId { get; set; }
        public int TransportStaffId { get; set; }
        public int VehicleId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TransportStaff TransportStaff { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
