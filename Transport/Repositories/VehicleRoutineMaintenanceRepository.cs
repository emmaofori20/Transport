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
    public class VehicleRoutineMaintenanceRepository: IVehicleRoutineMaintenanceRepository
    {
        private readonly TransportDbContext _context;

        public VehicleRoutineMaintenanceRepository(TransportDbContext context)
        {
            this._context = context;
        }

        public List<VehicleRoutineMaintenance> GetAllRoutineMaintenances()
        {
            return _context.VehicleRoutineMaintenances
                    .Include(x=>x.Vehicle)
                    .Include(x => x.RoutineMaintenanceLists)
                    .ToList();
        }

        public VehicleRoutineMaintenance AddRoutineRequest(RoutineMaintenanceVehicleViewModel model)
        {
            var res = new VehicleRoutineMaintenance()
            {
                VehicleId= model.VehicleId,
                IsDeleted=false,
                CreatedBy= "Admin",
                CreatedOn=DateTime.Now

            };

            _context.VehicleRoutineMaintenances.Add(res);
            _context.SaveChanges();

            return res;
        }

        public List<RoutineMaintenanceList> GetRoutineMaintenance(int RoutineId)
        {
            return _context.RoutineMaintenanceLists
                .Include(x => x.VehicleRoutineMaintenance)
                .Include(x => x.SparePart)
                .Include(x => x.RoutineMaintenanceActivity)
                .Where(x=>x.VehicleRoutineMaintenanceId ==RoutineId).ToList();
        }
    }
}
