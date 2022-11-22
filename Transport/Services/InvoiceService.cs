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
        public void ApproveInvoice(int RequestId, string Issuer)
        {
            vehicleMaintenanceRequestStatusRepository.ApproveVehicleMaintenance(RequestId, Issuer);
        }

        public void CompleteInvoice(int RequestId, string Issuer)
        {
            throw new NotImplementedException();
        }


        public void InvalidInvoice(int RequestId, string Issuer)
        {
            vehicleMaintenanceRequestStatusRepository.InvalidVehicleMaintenanceRequest(RequestId, Issuer);
        }

        public void UnApprovedInvoice(int RequestId, string Issuer)
        {
            vehicleMaintenanceRequestStatusRepository.UnApproveVehicleMaintenance(RequestId, Issuer);
        }

        #endregion

        #region ReqestTypes

        public List<RequestType> GetRequestTypes()
        {
            return requestTypeRepository.GetAllRequestType();
        }

        public void CreateRequestType(RequestTypesViewModel model, string Issuer)
        {
            requestTypeRepository.CreateRequestType(model, Issuer);
        }

        public RequestType GetSingleRequestType(int RequestTypeId)
        {
            return GetRequestTypes().Where(x => x.RequestTypeId == RequestTypeId).FirstOrDefault();
        }

        public void EditRequestType(RequestTypeNameAndChargeViewModel model, string Issuer)
        {
            requestTypeRepository.EditRequestType(model, Issuer);
        }

        public void DeleteRequestType(int RequestTypeId, string Issuer)
        {
            requestTypeRepository.DeleteRequestType(RequestTypeId, Issuer);
        }
        #endregion
    }
}
