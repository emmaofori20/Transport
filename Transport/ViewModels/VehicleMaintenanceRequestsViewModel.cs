using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class VehicleMaintenanceRequestsViewModel
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public string MaintainedBy { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int RequestId { get; set; }
        public List<VehicleMaintenanceRequestItem> spareParts { get; set; }
        public decimal MaintenanceCost { get; set; }
    }

    public class VehicleRoutineMaintenanceRequestViewModel
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public string MaintainedBy { get; set; }
        public int RoutineRequestId { get; set; }
        public DateTime Date { get; set; }


    }
}
