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

        public void PendingVehicleMaintenanceRequestStatus( int vehicleMaintenanceRequestId)
        {
            VehicleMaintenanceRequestStatus vehicleMaintenanceRequestStatus = new VehicleMaintenanceRequestStatus
            {
                VehicleMaintenanceRequestId = vehicleMaintenanceRequestId,
                MaintainanceStatusId = 3000,
                CreatedBy="AdminTest",
                CreatedOn=DateTime.Now
            };

            _context.VehicleMaintenanceRequestStatuses.Add(vehicleMaintenanceRequestStatus);
            _context.SaveChanges();
        }
    }
}
