using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class RequestMaintenanceViewModel
    {
        [Required]
        public int RegistrationNumber { get; set; }
        [Required]
        public string MaintenanceDescription { get; set; }
        public string CreatedBy { get; set; }
        public double MaintenanceCost { get; set; }
        public string MaintainedBy { get; set; }
        public SelectList Vehicles { get; set; }
    }
}
