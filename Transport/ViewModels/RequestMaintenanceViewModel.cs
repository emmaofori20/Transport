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
        public string RegistrationNumber { get; set; }
        [Required]
        public string MaintenanceDescription { get; set; }
        [Required]
        public double MaintenanceCost { get; set; }
        public string MaintainedBy { get; set; }
    }
}
