using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;

namespace Transport.Repositories
{
    public class RequestTypeRepository: IRequestTypeRepository
    {
        private readonly TransportDbContext _context;

        public RequestTypeRepository(TransportDbContext context)
        {
            _context = context;
        }

        public void CreateRequestType(RequestTypesViewModel model)
        {
            var res = new RequestType
            {
                RequestTypeName = model.NewReqestTypeNameAndCharge.RequestTypeName,
                IsDeleted = false,
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now
            };
            _context.RequestTypes.Add(res);
            _context.SaveChanges();
            model.NewReqestTypeNameAndCharge.RequestTypeId = res.RequestTypeId;
            AddRequestTypeCharge(model.NewReqestTypeNameAndCharge);
        }

        public void AddRequestTypeCharge(RequestTypeNameAndChargeViewModel model)
        {
            var res = new RequestTypeCharge
            {
                RequestTypeId = model.RequestTypeId,
                IsActive = true,
                ActiveFrom = DateTime.Now,
                ChargeName = model.RequestTypeChargeName,
                ChargeValue = model.RequestTypeChargeValue
            };

            _context.RequestTypeCharges.Add(res);
            _context.SaveChanges();
        }

        public List<RequestType> GetAllRequestType()
        {
           return _context.RequestTypes.Include(x => x.RequestTypeCharges).Where(x=>x.IsDeleted == false).ToList();
        }

        public void EditRequestType(RequestTypeNameAndChargeViewModel model)
        {
            var res = _context.RequestTypes.Find(model.RequestTypeId);

            if (res!=null)
            {
                res.RequestTypeName = model.RequestTypeName;
                _context.RequestTypes.Update(res);

                var requestTypeCharge = _context.RequestTypeCharges.Find(model.RequestTypeChargeId);
                if(requestTypeCharge != null)
                {
                    //set previous value to false
                    requestTypeCharge.IsActive = false;
                    requestTypeCharge.ActiveTo = DateTime.Now;
                    _context.RequestTypeCharges.Update(requestTypeCharge);
                    _context.SaveChanges();
                    //Add new value
                    AddRequestTypeCharge(model);
                }
            }
        }

        public void DeleteRequestType(int RequestId)
        {
            var res = _context.RequestTypes.Find(RequestId);
            if (res != null)
            {
                res.IsDeleted = true;
                res.UpdatedBy = "UpdatedAdmin";
                res.UpdatedOn = DateTime.Now;
                _context.RequestTypes.Update(res);
                _context.SaveChanges();
                
            }
        }
    }
}
