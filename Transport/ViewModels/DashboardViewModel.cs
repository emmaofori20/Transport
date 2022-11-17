using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalVehicleNumber { get; set; }
        public int TotalUsersNumber { get; set; }
        public int TotalNumberOfNewMaintenanceRequests { get; set; }
        public int TotalNumberOfNewHiringRequests { get; set; }
        public List<int> RequestCountPerMonth { get; set; }
        public List<int> RoutineCountPerMonth { get; set; }
    }
}
