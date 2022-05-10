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
    public class VehicleMaintenanceRequestRepository: IVehicleMaintenanceRequestRepository
    {
        private readonly TransportDbContext _context;

        public VehicleMaintenanceRequestRepository(TransportDbContext context)
        {
           _context = context;
        }

        public VehicleMaintenanceRequest GetMaintenanceRequest(int RequestId)
        {
            return _context.VehicleMaintenanceRequests
                .Where(x => x.VehicleMaintenanceRequestId == RequestId)
                .FirstOrDefault();
        }

        public List<VehicleMaintenanceRequest> GetAllMaintenanceRequest()
        {
            return _context.VehicleMaintenanceRequests
                .Include(x=>x.VehicleMaintenanceSpareparts)
                .Include(x => x.VehicleMaintenanceRequestStatuses)
                .ThenInclude(x => x.MaintenanceStatus)
                .ToList();
        }

        public VehicleMaintenanceRequest VehicleMaintenanceRequest(RequestMaintenanceViewModel model)
        {
            //Saving/adding Request Maintenance Data into the database
            VehicleMaintenanceRequest vehicleMaintenanceRequest = new VehicleMaintenanceRequest
            {
                VehicleId = 1,
                MaintenanceDescription = model.MaintenanceDescription,
                CreatedBy = "AdminTest",
                CreatedOn = DateTime.Now
            };
            _context.Add(vehicleMaintenanceRequest);
            _context.SaveChanges();
            return vehicleMaintenanceRequest;
        }

        public void DeleteVehicleRequestMaintenance(int RequestId)
        {
            var VehicleMaintenanceRepuest = _context.VehicleMaintenanceRequests
                                        .Where(x=>x.VehicleMaintenanceRequestId == RequestId)
                                        .Include(x => x.VehicleMaintenanceRequestStatuses)
                                        .Include(x => x.VehicleMaintenanceSpareparts).FirstOrDefault();

            foreach (var vehicleRequestStatus in VehicleMaintenanceRepuest.VehicleMaintenanceRequestStatuses)
            {
                _context.Remove(vehicleRequestStatus);
                _context.SaveChanges();
            }

            foreach (var spareParts in VehicleMaintenanceRepuest.VehicleMaintenanceSpareparts)
            {
                _context.Remove(spareParts);
                _context.SaveChanges();

            }

            _context.Remove(VehicleMaintenanceRepuest);
            _context.SaveChanges();
        }

        public void EditVehicleRequestMaintenance(int RequestId, RequestMaintenanceViewModel model)
        {
            VehicleMaintenanceRequest vehicleMaintenance= GetMaintenanceRequest(RequestId);
            vehicleMaintenance.MaintenanceDescription = model.MaintenanceDescription;
            vehicleMaintenance.UpdatedBy = "UpdatedAdmin";
            vehicleMaintenance.UpdatedOn = DateTime.Now;

            _context.VehicleMaintenanceRequests.Update(vehicleMaintenance);
            _context.SaveChanges();
        }
    }
}
