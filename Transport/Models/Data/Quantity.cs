using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Quantity
    {
        public Quantity()
        {
            VehicleAxleCountNavigations = new HashSet<Vehicle>();
            VehicleCylinderCountNavigations = new HashSet<Vehicle>();
            VehiclePersonCountNavigations = new HashSet<Vehicle>();
            VehicleWheelCountNavigations = new HashSet<Vehicle>();
        }

        public int QuantityId { get; set; }
        public int Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicle> VehicleAxleCountNavigations { get; set; }
        public virtual ICollection<Vehicle> VehicleCylinderCountNavigations { get; set; }
        public virtual ICollection<Vehicle> VehiclePersonCountNavigations { get; set; }
        public virtual ICollection<Vehicle> VehicleWheelCountNavigations { get; set; }
    }
}
