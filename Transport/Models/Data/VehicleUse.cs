﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleUse
    {
        public VehicleUse()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int VehicleUseId { get; set; }
        public string UseName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
