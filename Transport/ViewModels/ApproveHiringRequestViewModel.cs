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

        public ApproveHireRequest approveHireRequest { get; set; }

    }

    public class ApproveHireRequest
    {
        public int HirerId { get; set; }
        public decimal HireCostFee { get; set; }
        public decimal WashingFee { get; set; }
        public decimal DriverFee { get; set; }
        [Required]
        public int VehicleId { get; set; }
        public SelectList Vehicles { get; set; }
    }
}
