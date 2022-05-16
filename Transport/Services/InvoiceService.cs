using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Repositories.IRepository;
using Transport.Services.IServices;

namespace Transport.Services
{
    public class InvoiceService: IInvoiceService
    {
        private readonly IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository;

        public InvoiceService(IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository)
        {
            this.vehicleMaintenanceRequestStatusRepository = vehicleMaintenanceRequestStatusRepository;
        }

        public void ApproveInvoice(int RequestId)
        {
            vehicleMaintenanceRequestStatusRepository.ApproveVehicleMaintenance(RequestId);
        }

        public void CompleteInvoice()
        {
            throw new NotImplementedException();
        }

        public void InvalidInvoice(int RequestId)
        {
            vehicleMaintenanceRequestStatusRepository.InvalidVehicleMaintenanceRequest(RequestId);
        }

        public void UnApprovedInvoice(int RequestId)
        {
            vehicleMaintenanceRequestStatusRepository.UnApproveVehicleMaintenance(RequestId);
        }
    }
}
