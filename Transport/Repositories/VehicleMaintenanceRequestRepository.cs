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
            return _context.VehicleMaintenanceRequests.Include(x=>x.Vehicle).Include(x=>x.VehicleRequestPhotoReceipts)
                .Where(x => x.VehicleMaintenanceRequestId == RequestId)
                .FirstOrDefault();
        }

        public List<VehicleMaintenanceRequest> GetAllMaintenanceRequest()
        {
            return _context.VehicleMaintenanceRequests
                .Include(x=>x.Vehicle)
                .Include(x=>x.VehicleMaintenanceSpareparts)
                .Include(x => x.VehicleMaintenanceRequestStatuses)
                .ThenInclude(x => x.Status)
                .Where(x=>x.IsDeleted != true)
                .ToList();
        }

        public VehicleMaintenanceRequest VehicleMaintenanceRequest(RequestMaintenanceViewModel model)
        {
            //Saving/adding Request Maintenance Data into the database
            VehicleMaintenanceRequest vehicleMaintenanceRequest = new VehicleMaintenanceRequest
            {
                VehicleId = model.RegistrationNumber,
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

            if (VehicleMaintenanceRepuest != null)
            {
                VehicleMaintenanceRepuest.IsDeleted = true;
                VehicleMaintenanceRepuest.UpdatedBy = "DeletedAdmin";
                VehicleMaintenanceRepuest.UpdatedOn = DateTime.Now;
            }

            _context.VehicleMaintenanceRequests.Update(VehicleMaintenanceRepuest);
            _context.SaveChanges();
        }

        public void EditVehicleRequestMaintenance(int RequestId, RequestMaintenanceViewModel model)
        {
            VehicleMaintenanceRequest vehicleMaintenance= GetMaintenanceRequest(RequestId);
            vehicleMaintenance.MaintenanceDescription = model.MaintenanceDescription;
            vehicleMaintenance.VehicleId = model.RegistrationNumber;
            vehicleMaintenance.UpdatedBy = "UpdatedAdmin";
            vehicleMaintenance.UpdatedOn = DateTime.Now;

            _context.VehicleMaintenanceRequests.Update(vehicleMaintenance);
            _context.SaveChanges();
        }
    }
}
