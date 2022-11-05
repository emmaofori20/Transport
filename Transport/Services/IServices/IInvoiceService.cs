using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
    public interface IInvoiceService
    {
        public void ApproveInvoice(int RequestId);
        public void InvalidInvoice(int RequestId);
        public void CompleteInvoice(int RequestId);
        public void UnApprovedInvoice(int RequestId);

        public List<RequestType> GetRequestTypes();
        public void CreateRequestType(RequestTypesViewModel model);
        public RequestType GetSingleRequestType(int RequestTypeId);
        public void EditRequestType(RequestTypeNameAndChargeViewModel model);
        public void DeleteRequestType(int RequestTypeId);
    }
}
