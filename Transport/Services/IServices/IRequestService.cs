using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
    public interface IRequestService
    {
        public VehicleMaintenanceRequest MakeRequestMaintenance( RequestMaintenanceViewModel model);

        public void AddRequestSparePart(List<VehicleMaintananceSparepartViewModel> model, int SparePartListId);

        public VehicleMaintenanceRequestDetailsViewModel VehicleMaintenanceRequestDetails(int ListId);

        public List<VehicleMaintenanceRequestsViewModel> GetAllVehicleMaintenanceRequest();

        public void DeleteVehicleRequestMaintenance(int RequestId);

        public void EdiVehicleRequestMaintenance(VehicleMaintenanceRequestDetailsViewModel model,int RequestId);
    }
}
