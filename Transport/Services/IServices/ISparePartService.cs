using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
    public interface ISparePartService
    {
        public (List<SparePartQuantity>, List<SparePartQuantity> AllSparePartsHistory) GetAllSpareParts();

        public void AddSparePart( SparePartViewModel model);

        public SparePartQuantity GetSparePart(int SparePartId);

        public void EditSparePart(SparePartViewModel model);

        public void DeleteSparePart(int sparePartId, string Issuer);
        public List<RoutineMaintenanceActivity> GetRoutineMaintenanceActivities();

        public void DeleteRoutineActivity(int RoutineActivityId, string Issuer);

        public void CreateRoutineActivity(RoutineActivityViewModel model);

        public void EditRoutineActivity(RoutineMaintenanceActivity model);
    }
}
