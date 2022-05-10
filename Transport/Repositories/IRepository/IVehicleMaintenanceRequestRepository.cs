using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
   public interface IVehicleMaintenanceRequestRepository
    {
        public VehicleMaintenanceRequest VehicleMaintenanceRequest(RequestMaintenanceViewModel model);

        public VehicleMaintenanceRequest GetMaintenanceRequest(int RequestId);

        public List<VehicleMaintenanceRequest> GetAllMaintenanceRequest();

        public void DeleteVehicleRequestMaintenance(int RequestId);

        public void EditVehicleRequestMaintenance(int RequestId, RequestMaintenanceViewModel model);
    }
}
