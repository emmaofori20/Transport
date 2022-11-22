using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;
using Transport.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Transport.Repositories
{
    public class VehicleMaintenanceRequestItemRepository : IVehicleMaintenanceRequestItemRepository
    {
        private readonly TransportDbContext _context;
        private readonly IRequestTypeRepository requestTypeRepository;

        public VehicleMaintenanceRequestItemRepository(TransportDbContext context, IRequestTypeRepository requestTypeRepository)
        {
            _context = context;
            this.requestTypeRepository = requestTypeRepository;
        }

        public RequestTypeCharge GetRequestCharge(int requestId)
        {
            return _context.RequestTypeCharges.Where(x => x.RequestTypeId == requestId && x.IsActive == true).FirstOrDefault();
        }
        public void AddVehicleMaintenanceSparePart(VehicleMaintananceSparepartViewModel sparePart, int ListId, string Issuer)
        {
            VehicleMaintenanceRequestItem vehicleMaintenanceSparepart = new VehicleMaintenanceRequestItem
            {
                Quantity =sparePart.Quantity,
                NameOfPart = sparePart.SparePartName,
                VehicleMaintenanceRequestId = ListId,
                Amount = (decimal)sparePart.Amount,
                RequestTypeId = sparePart.RequestTypeId,
                RequestTypeChargeId = GetRequestCharge(sparePart.RequestTypeId).RequestTypeChargeId,
                CreatedBy= Issuer,
                CreatedOn= DateTime.Now
            };

            _context.VehicleMaintenanceRequestItems.Add(vehicleMaintenanceSparepart);
            _context.SaveChanges();
        }

        public void DeleteAllVehicleMaintenanceSparepart(int ListId)
        {
            //get all spare parts with that Id
            var results= GetList(ListId);

            foreach (var item in results)
            {
                _context.VehicleMaintenanceRequestItems.Remove(item);
                _context.SaveChanges();

            }
        }

        public List<VehicleMaintenanceRequestItem> GetList(int Id)
        {
            var results = _context.VehicleMaintenanceRequestItems.Where(x => x.VehicleMaintenanceRequestId == Id)
                .Include(x=>x.RequestType)
                .Include(x=>x.RequestTypeCharge).ToList();
            return results;
        }
    }
}
