using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.Repositories.IRepository
{
    public class VehicleMaintenanceRequestStatusRepository: IVehicleMaintenanceRequestStatusRepository
    {
        private readonly TransportDbContext _context;

        public VehicleMaintenanceRequestStatusRepository(TransportDbContext context)
        {
            _context = context;
        }

        //Approving a request 
        public void ApproveVehicleMaintenance(int RequestId)
        {
            VehicleMaintenanceRequestStatus ApproveVehicleMaintenanceRequest = new VehicleMaintenanceRequestStatus
            {
                VehicleMaintenanceRequestId = RequestId,
                MaintenanceStatusId = 3001,
                CreatedBy = "AdminTest",
                CreatedOn = DateTime.Now,
                UpdatedBy = "ApprovedAdmin",
                UpdatedOn = DateTime.Now
            };

            _context.VehicleMaintenanceRequestStatuses.Add(ApproveVehicleMaintenanceRequest);
            _context.SaveChanges();
        }

        public VehicleMaintenanceRequestStatus GetVehicleMaintenanceRequestStatus(int RequestId)
        {
           var result= _context.VehicleMaintenanceRequestStatuses.Include(x => x.MaintenanceStatus)
                        .OrderByDescending(x=>x.CreatedOn)
                        .FirstOrDefault(x=>x.VehicleMaintenanceRequestId == RequestId);
           return result;
        }

        public void InvalidVehicleMaintenanceRequest(int RequestId)
        {
            var results = _context.VehicleMaintenanceRequestStatuses.Where(x => x.VehicleMaintenanceRequestId == RequestId)
                         .OrderByDescending(x => x.CreatedOn).First();

            if (results != null)
            {
                results.UpdatedBy = "Invalid Engineer";
                results.UpdatedOn = DateTime.Now;
                results.MaintenanceStatusId = 3003;
            }
            _context.VehicleMaintenanceRequestStatuses.Update(results);
            _context.SaveChanges();
        }

        //Setting a request to pending
        public void PendingVehicleMaintenanceRequestStatus( int vehicleMaintenanceRequestId)
        {
            VehicleMaintenanceRequestStatus vehicleMaintenanceRequestStatus = new VehicleMaintenanceRequestStatus
            {
                VehicleMaintenanceRequestId = vehicleMaintenanceRequestId,
                CreatedBy="AdminTest",
                CreatedOn=DateTime.Now,
                MaintenanceStatusId = 3000
                
            };

            _context.VehicleMaintenanceRequestStatuses.Add(vehicleMaintenanceRequestStatus);
            _context.SaveChanges();
        }

        //Unapproving a request
        public void UnApproveVehicleMaintenance(int RequestId)
        {
           var results= _context.VehicleMaintenanceRequestStatuses.Where(x=>x.VehicleMaintenanceRequestId == RequestId)
                .OrderByDescending(x => x.CreatedOn).First();

            if (results != null)
            {
                results.UpdatedBy = "UNApproved Engineer";
                results.UpdatedOn = DateTime.Now;
                results.MaintenanceStatusId = 3000;
            }
            _context.VehicleMaintenanceRequestStatuses.Update(results);
            _context.SaveChanges();
        }
    }
}
