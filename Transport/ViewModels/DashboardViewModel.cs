using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalVehicleNumber { get; set; }
        public int TotalSparepartNumber { get; set; }
        public int TotalUsersNumber { get; set; }
        public int VehicleMaintenanceRequestNumber { get; set; }
    }
}
