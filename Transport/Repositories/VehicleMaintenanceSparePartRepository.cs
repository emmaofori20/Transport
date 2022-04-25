using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class VehicleMaintenanceSparePartRepository: IVehicleMaintenanceSparePart
    {
        private readonly TransportDbContext _context;

        public VehicleMaintenanceSparePartRepository(TransportDbContext context)
        {
            _context = context;

        }

        public void AddVehicleMaintenanceSparePart(VehicleMaintananceSparepartViewModel sparePart, int ListId)
        {
            VehicleMaintenanceSparepart vehicleMaintenanceSparepart = new VehicleMaintenanceSparepart
            {
                Quantity =sparePart.Quantity,
                NameOfPart = sparePart.SparePartName,
                VehicleMaintenanceRequestId = ListId,
                CreatedBy= "Admin",
                CreatedOn= DateTime.Now
            };

            _context.VehicleMaintenanceSpareparts.Add(vehicleMaintenanceSparepart);

        }
    }
}
