using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IVehicleMaintenanceSparePart
    {
        public void AddVehicleMaintenanceSparePart(VehicleMaintananceSparepartViewModel sparePart, int ListId);
    }
}
