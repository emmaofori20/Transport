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
        public (List<SparePartQuantity>, List<SparePartQuantity> spareparts) GetAllSpareParts();

        public void AddSparePart( SparePartViewModel model);

        public SparePartQuantity GetSparePart(int SparePartId);

        public void EditSparePart(SparePartViewModel model);

        public void DeleteSparePart(int sparePartId);
        public List<RoutineMaintenanceActivity> GetRoutineMaintenanceActivities();

        public void DeleteRoutineActivity(int RoutineActivityId);
    }
}
