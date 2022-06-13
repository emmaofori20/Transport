using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IVehicleRoutineMaintenanceRepository 
    {
        public List<VehicleRoutineMaintenance> GetAllRoutineMaintenances();
        public VehicleRoutineMaintenance AddRoutineRequest(RoutineMaintenanceVehicleViewModel model);
        public List<RoutineMaintenanceList> GetRoutineMaintenance(int RoutineId);
    }
}
