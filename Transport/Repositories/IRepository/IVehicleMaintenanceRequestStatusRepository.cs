using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.Repositories.IRepository
{
    public interface IVehicleMaintenanceRequestStatusRepository
    {
        public void PendingVehicleMaintenanceRequestStatus(int  vehicleMaintenanceRequestId, string Issuer );

        public VehicleMaintenanceRequestStatus GetVehicleMaintenanceRequestStatus(int RequestId);

        //Just adding a new insertion
        public void ApproveVehicleMaintenance(int RequestId, string Issuer);

        //Removing/Unapproing a RequestMaintenance
        public void UnApproveVehicleMaintenance(int RequestId, string Issuer);
        public void InvalidVehicleMaintenanceRequest(int RequestI, string Issuerd);
        public void CompleteVehicleMaintenanceRequest(int RequestId, string Issuer);
    }
}
