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
        private readonly ISparePartQuantityRepository sparePartQuantityRepository;

        public RoutneMaintenanceListRepository(TransportDbContext context, ISparePartQuantityRepository sparePartQuantityRepository)
        {
            this._context = context;
            this.sparePartQuantityRepository = sparePartQuantityRepository;
        }

        public void AddRoutineMaintenanceLsit(RoutineActivityCheck Activity, int RoutineMaintenanceId, string Issuer)
        {
            if (Activity.Isokay && Activity.IsRequiredSparePart)
            {
                ////Substract the quantity of spareparts used for the activity and proceed
                sparePartQuantityRepository.SubtractSparePartQuantityAfterRoutineMaintenanceActivity(Activity,Issuer);
                ////Substract the quantity of spareparts used for the activity and proceed

                var RoutineActivity = new RoutineMaintenanceList
                {
                    VehicleRoutineMaintenanceId = RoutineMaintenanceId,
                    RoutineMaintenanceActivityId = Activity.ActivityId,
                    Quantity = (int)Activity.Quantity,
                    SparePartId= Activity.SparePartId,
                    IsSparePartUsed =true,
                    IsRoutineCheck = true,
                    CreatedBy= Issuer,
                    CreatedOn = DateTime.Now
                };

                _context.RoutineMaintenanceLists.Add(RoutineActivity);
                _context.SaveChanges();
            }else if (Activity.Isokay )
            {
                var RoutineActivity = new RoutineMaintenanceList
                {
                    VehicleRoutineMaintenanceId = RoutineMaintenanceId,
                    RoutineMaintenanceActivityId = Activity.ActivityId,
                    IsSparePartUsed = false,
                    IsRoutineCheck = true,
                    CreatedBy = Issuer,
                    CreatedOn = DateTime.Now
                };
                _context.RoutineMaintenanceLists.Add(RoutineActivity);
                _context.SaveChanges();
            }
            else
            {
                var RoutineActivity = new RoutineMaintenanceList
                {
                    VehicleRoutineMaintenanceId = RoutineMaintenanceId,
                    RoutineMaintenanceActivityId = Activity.ActivityId,
                    IsRoutineCheck =false,
                    IsSparePartUsed =false,
                    CreatedBy = Issuer,
                    CreatedOn = DateTime.Now
                };
                _context.RoutineMaintenanceLists.Add(RoutineActivity);
                _context.SaveChanges();
            }
        }

        public void EditRoutineMaintenanceList(RoutineActivityCheck Activity, int RoutineMaintenanceid, string Issuer)
        {
            var RoutineActivity = _context.RoutineMaintenanceLists
                .Where(x=>x.VehicleRoutineMaintenanceId == RoutineMaintenanceid && x.RoutineMaintenanceActivityId == Activity.ActivityId).FirstOrDefault();
            if (RoutineActivity != null)
            {
                RoutineActivity.IsRoutineCheck = Activity.Isokay;
                RoutineActivity.IsSparePartUsed = Activity.IsRequiredSparePart;
                RoutineActivity.Quantity = (int?)Activity.Quantity;
                RoutineActivity.SparePartId = Activity.SparePartId == 0 ? null: Activity.SparePartId;
                RoutineActivity.UpdatedBy = Issuer;
                RoutineActivity.UpdatedOn = DateTime.Now;

                _context.RoutineMaintenanceLists.Update(RoutineActivity);
                _context.SaveChanges();
            }
        }
    }
}
