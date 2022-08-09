using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Services
{
    public class SparePartService: ISparePartService
    {
        private readonly ISparePartQuantityRepository sparePartQuantityRepository;

        public SparePartService(ISparePartQuantityRepository sparePartQuantityRepository)
        {
            this.sparePartQuantityRepository = sparePartQuantityRepository;
        }

        public void AddSparePart(SparePartViewModel model)
        {
            sparePartQuantityRepository.AddSparePart(model);
        }

        public void EditSparePart(SparePartViewModel model)
        {
            sparePartQuantityRepository.UpdateSpareQuantity(model);
            //throw new NotImplementedException();
        }

        public (List<SparePartQuantity>, List<SparePartQuantity> AllSparePartsHistory) GetAllSpareParts()
        {
            var res = sparePartQuantityRepository.GetSpareParts();

            List<SparePartQuantity> sparePartQuantities = new List<SparePartQuantity>();

            var number = res.Select(x=>x.SparePartId).Distinct().ToList();/// Selecting only distinct Spare Part Id from the response(res)

            for (int i = 0; i < number.Count(); i++)
            {
                /////Selecting Current CreatedON which distinct Id////////// 
                sparePartQuantities.Add(res.OrderByDescending(x => x.CreatedOn).FirstOrDefault(x=>x.SparePartId == number[i]));
                /////Selecting Current CreatedON which distinct Id////////// 

            }

            return (sparePartQuantities, res);
        }

        public SparePartQuantity GetSparePart(int SparePartId)
        {
            SparePartQuantity sparePartQuantity = GetAllSpareParts().Item1.
                                            Where(x=>x.SparePartId== SparePartId).OrderByDescending(x=>x.CreatedOn).FirstOrDefault();
            
            return sparePartQuantity;
        }

        public void DeleteSparePart(int sparePartId)
        {
            sparePartQuantityRepository.DeleteSparePart(sparePartId);
        }
        /// <summary>
        /// ROUTINE ACTIVITY
        /// </summary>
        /// <returns></returns>
        public List<RoutineMaintenanceActivity> GetRoutineMaintenanceActivities()
        {
            return sparePartQuantityRepository.GetRoutineMaintenanceActivities();
        }

        public void DeleteRoutineActivity(int RoutineActivityId)
        {
            sparePartQuantityRepository.DeleteRoutineActivity(RoutineActivityId);
        }

        public void CreateRoutineActivity(RoutineActivityViewModel model)
        {
            sparePartQuantityRepository.AddRoutineActivity(model);
        }

        public void EditRoutineActivity(RoutineMaintenanceActivity model)
        {
            sparePartQuantityRepository.EditRoutineActivity(model);
        }
    }
}
