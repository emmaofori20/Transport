using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class TransportStaff
    {
        public TransportStaff()
        {
            VehicleTransportStaffs = new HashSet<VehicleTransportStaff>();
        }

        public int TransportStaffId { get; set; }
        public string Surname { get; set; }
        public string Othernames { get; set; }
        public string StaffType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<VehicleTransportStaff> VehicleTransportStaffs { get; set; }
    }
}
