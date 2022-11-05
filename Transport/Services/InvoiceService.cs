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
    public class InvoiceService: IInvoiceService
    {
        private readonly IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository;
        private readonly IRequestTypeRepository requestTypeRepository;

        public InvoiceService(IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository,
                                IRequestTypeRepository requestTypeRepository)
        {
            this.vehicleMaintenanceRequestStatusRepository = vehicleMaintenanceRequestStatusRepository;
            this.requestTypeRepository = requestTypeRepository;
        }

        #region InvoiceService
        public void ApproveInvoice(int RequestId)
        {
            vehicleMaintenanceRequestStatusRepository.ApproveVehicleMaintenance(RequestId);
        }

        public void CompleteInvoice(int RequestId)
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

        #endregion

        #region ReqestTypes

        public List<RequestType> GetRequestTypes()
        {
            return requestTypeRepository.GetAllRequestType();
        }

        public void CreateRequestType(RequestTypesViewModel model)
        {
            requestTypeRepository.CreateRequestType(model);
        }

        public RequestType GetSingleRequestType(int RequestTypeId)
        {
            return GetRequestTypes().Where(x => x.RequestTypeId == RequestTypeId).FirstOrDefault();
        }

        public void EditRequestType(RequestTypeNameAndChargeViewModel model)
        {
            requestTypeRepository.EditRequestType(model);
        }

        public void DeleteRequestType(int RequestTypeId)
        {
            requestTypeRepository.DeleteRequestType(RequestTypeId);
        }
        #endregion
    }
}
