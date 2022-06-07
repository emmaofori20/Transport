using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class PermAxleLoad
    {
        public PermAxleLoad()
        {
            VehicleFrontPermAxleLoadNavigations = new HashSet<Vehicle>();
            VehicleMiddlePermAxleLoadNavigations = new HashSet<Vehicle>();
            VehicleRearPermAxleLoadNavigations = new HashSet<Vehicle>();
        }

        public int PermAxleLoadId { get; set; }
        public decimal PermAxleLoadValue { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicle> VehicleFrontPermAxleLoadNavigations { get; set; }
        public virtual ICollection<Vehicle> VehicleMiddlePermAxleLoadNavigations { get; set; }
        public virtual ICollection<Vehicle> VehicleRearPermAxleLoadNavigations { get; set; }
    }
}
