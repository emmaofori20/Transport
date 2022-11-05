using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class ApproveHiringRequestViewModel
    {
        public HireDetailsViewModel hireDetails { get; set; }
        public SelectList Vehicles { get; set; }
        public List<ApproveHireRequest> approveHireRequest { get; set; }
        public SelectList Drivers { get; set; }
        public CompletedHireRequest completedHireRequest { get; set; }
    }

    public class ApproveHireRequest
    {
        [Required]public int VehicleId { get; set; }
        public decimal CalculatedCost { get; set; }

        public int HirerId { get; set; }
        public decimal WashingFee { get; set; }
        public decimal DriverFee { get; set; }
        [Required] public int DriverId { get; set; }
        public string RegistrationNumber { get; set; }
        public string DriverName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateTimeReturned { get; set; }
    }

    public class CompletedHireRequest
    {
        public int HirerId { get; set; }
        public DateTime DateTimeReturned { get; set; }

    }
}
