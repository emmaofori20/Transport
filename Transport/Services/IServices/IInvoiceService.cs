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
        public void ApproveInvoice(int RequestId, string Issuer);
        public void InvalidInvoice(int RequestId, string Issuer);
        public void CompleteInvoice(int RequestId, string Issuer);
        public void UnApprovedInvoice(int RequestId, string Issuer);

        public List<RequestType> GetRequestTypes();
        public void CreateRequestType(RequestTypesViewModel model, string Issuer);
        public RequestType GetSingleRequestType(int RequestTypeId);
        public void EditRequestType(RequestTypeNameAndChargeViewModel model, string Issuer);
        public void DeleteRequestType(int RequestTypeId, string Issuer);
    }
}
