using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class RequestVehicleViewModel
    {

        public RequestMaintenanceViewModel requestMaintenance { get; set; }
        public SelectList AllVehicles { get; set; }
        public List< VehicleMaintenanceRequestsViewModel> VehicleMaintenanceRequests { get; set; }
        public List<VehicleRoutineMaintenance> VehicleRoutineMaintenanceRequest { get; set; }
    }
}
