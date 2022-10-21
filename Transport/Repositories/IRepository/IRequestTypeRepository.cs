using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IRequestTypeRepository
    {
        public List<RequestType> GetAllRequestType();
        public void CreateRequestType(RequestTypesViewModel model);

        public void EditRequestType(RequestTypeNameAndChargeViewModel model);
    }
}
