using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;

namespace Transport.Repositories
{
    public class RoutneMaintenanceListRepository: IRoutneMaintenanceListRepository
    {
        private readonly TransportDbContext _context;

        public RoutneMaintenanceListRepository(TransportDbContext context)
        {
            this._context = context;
        }

        public void AddRoutineMaintenanceLsit(RoutineActivityCheck Activity, int RoutineMaintenanceId)
        {
            if (Activity.Isokay && Activity.IsRequiredSparePart)
            {
                var RoutineActivity = new RoutineMaintenanceList
                {
                    VehicleRoutineMaintenanceId = RoutineMaintenanceId,
                    RoutineMaintenanceActivityId = Activity.ActivityId,
                    Quantity = (int)Activity.Quantity,
                    SparePartId= Activity.SparePartId,
                    IsSparePartUsed =true,
                    CreatedBy= "Admin",
                    CreatedOn = DateTime.Now
                };

                _context.RoutineMaintenanceLists.Add(RoutineActivity);
                _context.SaveChanges();
            }else if (Activity.Isokay)
            {
                var RoutineActivity = new RoutineMaintenanceList
                {
                    VehicleRoutineMaintenanceId = RoutineMaintenanceId,
                    RoutineMaintenanceActivityId = Activity.ActivityId,
                    IsSparePartUsed = false,
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now
                };
                _context.RoutineMaintenanceLists.Add(RoutineActivity);
                _context.SaveChanges();
            }
            else
            {

            }
        }
    }
}
