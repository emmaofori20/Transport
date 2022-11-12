using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface ISparePartQuantityRepository
    {
        public List<SparePartQuantity> GetSpareParts();
        public int GetSparepartCount();
        public void AddSparePart(SparePartViewModel model);
        public void UpdateSpareQuantity(SparePartViewModel model);
        public void DeleteSparePart(int sparePartId, string Issuer);
        public void SubtractSparePartQuantityAfterRoutineMaintenanceActivity(RoutineActivityCheck Activity, string Issuer);
        public void AddSparePartQuantityAfterRoutineMaintenanceActivity(RoutineActivityCheck Activity, string Issuer);
        /// <summary>
        /// Routine Activities
        /// </summary>
        /// <returns></returns>
        public List<RoutineMaintenanceActivity> GetRoutineMaintenanceActivities();
        public void DeleteRoutineActivity(int RoutineActivityId, string Issuer);
        public void EditRoutineActivity(RoutineMaintenanceActivity routineActivity);

        public void AddRoutineActivity(RoutineActivityViewModel model);
    }
}
