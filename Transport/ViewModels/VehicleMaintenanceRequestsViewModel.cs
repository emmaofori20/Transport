using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class VehicleMaintenanceRequestsViewModel
    {
        public int RegistrationNumber { get; set; }
        public decimal MaintenanceCost { get; set; }
        public string MaintainedBy { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int RequestId { get; set; }
        public int spareParts { get; set; }
    }
}
