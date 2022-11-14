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
                    .Where(x=>x.IsDeleted!=true)
                    .ToList();
        }

        public VehicleRoutineMaintenance AddRoutineRequest(RoutineMaintenanceVehicleViewModel model)
        {
            var res = new VehicleRoutineMaintenance()
            {
                VehicleId= model.VehicleId,
                IsDeleted=false,
                CreatedBy= model.CreatedBy,
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

        public void EditRoutineMaintenanceRequest(RoutineMaintenanceVehicleViewModel model)
        {
            var res = _context.VehicleRoutineMaintenances.Find(model.RoutineId);

            if (res != null)
            {
                res.UpdatedBy = model.CreatedBy;
                res.UpdatedOn = DateTime.Now;
                res.VehicleId = model.VehicleId;

                _context.VehicleRoutineMaintenances.Update(res);
                _context.SaveChanges();
            }
        }

        public void DeleteRoutineMaintenanceRequest(int RoutineId, string Issuer)
        {
            var res = _context.VehicleRoutineMaintenances.Find(RoutineId);

            if (res != null)
            {
                res.UpdatedBy = Issuer;
                res.UpdatedOn = DateTime.Now;
                res.IsDeleted = true;

                _context.VehicleRoutineMaintenances.Update(res);
                _context.SaveChanges();
            }
        }
    }
}
