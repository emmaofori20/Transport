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
        public void ApproveVehicleMaintenance(int RequestId, string Issuer)
        {
            VehicleMaintenanceRequestStatus ApproveVehicleMaintenanceRequest = new VehicleMaintenanceRequestStatus
            {
                VehicleMaintenanceRequestId = RequestId,
                StatusId = 2005,
                CreatedBy = Issuer,
                CreatedOn = DateTime.Now,
                UpdatedBy = Issuer,
                UpdatedOn = DateTime.Now
            };

            _context.VehicleMaintenanceRequestStatuses.Add(ApproveVehicleMaintenanceRequest);
            _context.SaveChanges();
        }

        public VehicleMaintenanceRequestStatus GetVehicleMaintenanceRequestStatus(int RequestId)
        {
           var result= _context.VehicleMaintenanceRequestStatuses.Include(x => x.Status)
                        .OrderByDescending(x=>x.CreatedOn)
                        .FirstOrDefault(x=>x.VehicleMaintenanceRequestId == RequestId);
           return result;
        }
        // setting a request to invalid
        public void InvalidVehicleMaintenanceRequest(int RequestId, string Issuer)
        {
            var results = _context.VehicleMaintenanceRequestStatuses.Where(x => x.VehicleMaintenanceRequestId == RequestId)
                         .OrderByDescending(x => x.CreatedOn).First();

            if (results != null)
            {
                results.UpdatedBy = Issuer;
                results.UpdatedOn = DateTime.Now;
                results.StatusId = 2007;
            }
            _context.VehicleMaintenanceRequestStatuses.Update(results);
            _context.SaveChanges();
        }

        //Setting a request to pending
        public void PendingVehicleMaintenanceRequestStatus( int vehicleMaintenanceRequestId, string Issuer)
        {
            VehicleMaintenanceRequestStatus vehicleMaintenanceRequestStatus = new VehicleMaintenanceRequestStatus
            {
                VehicleMaintenanceRequestId = vehicleMaintenanceRequestId,
                CreatedBy=Issuer,
                CreatedOn=DateTime.Now,
                StatusId = 2003
                
            };

            _context.VehicleMaintenanceRequestStatuses.Add(vehicleMaintenanceRequestStatus);
            _context.SaveChanges();
        }

        //Unapproving a request
        public void UnApproveVehicleMaintenance(int RequestId, string Issuer)
        {
           var results= _context.VehicleMaintenanceRequestStatuses.Where(x=>x.VehicleMaintenanceRequestId == RequestId)
                .OrderByDescending(x => x.CreatedOn).First();

            if (results != null)
            {
                results.UpdatedBy = Issuer;
                results.UpdatedOn = DateTime.Now;
                results.StatusId = 2003;
            }
            _context.VehicleMaintenanceRequestStatuses.Update(results);
            _context.SaveChanges();
        }

        //Completing a request
        public void CompleteVehicleMaintenanceRequest (int RequestId, string Issuer)
        {
            VehicleMaintenanceRequestStatus ApproveVehicleMaintenanceRequest = new VehicleMaintenanceRequestStatus
            {
                VehicleMaintenanceRequestId = RequestId,
                StatusId = 2006,
                CreatedBy = Issuer,
                CreatedOn = DateTime.Now,
                UpdatedBy = Issuer,
                UpdatedOn = DateTime.Now
            };

            _context.VehicleMaintenanceRequestStatuses.Add(ApproveVehicleMaintenanceRequest);
            _context.SaveChanges();
        }
    }
}
