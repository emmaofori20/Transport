using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Hirer
    {
        public Hirer()
        {
            HirerHiringStatuses = new HashSet<HirerHiringStatus>();
            Hirings = new HashSet<Hiring>();
        }

        public int HirerId { get; set; }
        public string OrganisationName { get; set; }
        public string ContactName { get; set; }
        public string PostalAddress { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string OtherContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public DateTime FinishDate { get; set; }
        public string Destination { get; set; }
        public string PurposeOfHire { get; set; }
        public int? NoOfPassengers { get; set; }
        public int? NoOfBusses { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int VehicleTypeForHireId { get; set; }
        public decimal DistanceCalculatedFromOrigin { get; set; }
        public decimal? DistanceCalaculatedFromOriginCost { get; set; }

        public virtual VehicleTypeForHire VehicleTypeForHire { get; set; }
        public virtual ICollection<HirerHiringStatus> HirerHiringStatuses { get; set; }
        public virtual ICollection<Hiring> Hirings { get; set; }
    }
}
