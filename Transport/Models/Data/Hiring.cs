using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Hiring
    {
        public int HiringId { get; set; }
        public decimal Price { get; set; }
        public string Hiree { get; set; }
        public DateTime TimeHired { get; set; }
        public DateTime? TimeReturned { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
