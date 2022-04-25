using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Services
{
    public class RequestService:IRequestService
    {
        public IVehicleMaintenanceRequestRepository _vehicleMaintenanceRequestRepository;
        private readonly IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository;

        public RequestService(IVehicleMaintenanceRequestRepository vehicleMaintenanceRequestRepository, IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository)
        {
            _vehicleMaintenanceRequestRepository = vehicleMaintenanceRequestRepository;
            this.vehicleMaintenanceRequestStatusRepository = vehicleMaintenanceRequestStatusRepository;
        }

        public VehicleMaintenanceRequest MakeRequestMaintenance(RequestMaintenanceViewModel model)
        {
            //Register the vehicle into the VehicleRequestMaintenance
            var VehicleMaintenanceRequest=  _vehicleMaintenanceRequestRepository
                                                    .VehicleMaintenanceRequest(model);
            //setting the status of the request
            vehicleMaintenanceRequestStatusRepository.PendingVehicleMaintenanceRequestStatus(VehicleMaintenanceRequest.VehicleMaintenanceRequestId);
            return VehicleMaintenanceRequest;
        }

        public void AddRequestSparePart(List<VehicleMaintananceSparepartViewModel> model, int SparePartListId)
        {
            throw new NotImplementedException();
        }
    }
}
