using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class TyreSize
    {
        public TyreSize()
        {
            VehicleFrontTyreSizeNavigations = new HashSet<Vehicle>();
            VehicleMiddleTyreSizeNavigations = new HashSet<Vehicle>();
            VehicleRearTyreSizeNavigations = new HashSet<Vehicle>();
        }

        public int TyreSizeId { get; set; }
        public string TyreSizeNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicle> VehicleFrontTyreSizeNavigations { get; set; }
        public virtual ICollection<Vehicle> VehicleMiddleTyreSizeNavigations { get; set; }
        public virtual ICollection<Vehicle> VehicleRearTyreSizeNavigations { get; set; }
    }
}
