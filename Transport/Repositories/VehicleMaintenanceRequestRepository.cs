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


        public VehicleMaintenanceRequest VehicleMaintenanceRequest(RequestMaintenanceViewModel model)
        {
            //Saving/adding Request Maintenance Data into the database
            VehicleMaintenanceRequest vehicleMaintenanceRequest = new VehicleMaintenanceRequest
            {
                MaintainedBy = model.MaintainedBy,
                MainteinanceCost = model.MaintenanceCost,
                VehicleId = 1,
                MaintenanceDescription = model.MaintenanceDescription,
                CreatedBy = "AdminTest",
                CreatedOn = DateTime.Now
            };
            _context.Add(vehicleMaintenanceRequest);
            _context.SaveChanges();
            return vehicleMaintenanceRequest;
        }
    }
}
