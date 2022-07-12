using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class HireDetailsViewModel
    {
        public string OrganisationName { get; set; }
        [Required]
        public string ContactName { get; set; }
        public string PostalAddress { get; set; }
        [Required]
        public string PrimaryContactNumber { get; set; }
        public string OtherContactNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan FinishTime { get; set; }
        [Required]
        public DateTime FinishDate { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string PurposeOfHire { get; set; }
        [Required]
        public int NoOfBusses { get; set; }
        public int VehicleTypeForHireId { get; set; }
        [Required]
        public int NoOfPassangers { get; set; }
        public int HireBusId { get; set; }
        public int HirerId { get; set; }
        public SelectList vehicleTypeForHire { get; set; }
        public string VehicleTypeForHireType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public decimal DistanceCalculatedFromOrigin { get; set; }
        public decimal DistanceCalculatedFromOrginCost { get; set; }
    }
}
