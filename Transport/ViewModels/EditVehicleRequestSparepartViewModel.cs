using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class EditVehicleRequestSparepartViewModel
    {
        public RequestMaintenanceViewModel requestMaintenance { get; set; }

        public List<VehicleMaintananceSparepartViewModel> VehicleMaintenanceSparepart { get; set; }

        public int RequestId { get; set; }
    }
}
