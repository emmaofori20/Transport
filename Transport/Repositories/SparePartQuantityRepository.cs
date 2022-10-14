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
    public class SparePartQuantityRepository : ISparePartQuantityRepository
    {
        private readonly TransportDbContext _context;

        public SparePartQuantityRepository(TransportDbContext context)
        {
            this._context = context;
        }
        public List<SparePartQuantity> GetSpareParts()
        {
            return _context.SparePartQuantities.Include(x => x.SparePart).Where(x=>x.IsDeleted!=true).ToList();
        }

        public SparePart AddSparePartName(string Name)
        {
            var sparePartName = new SparePart
            {
                SparePartName = Name,
                CreatedBy = "AdminSparePare",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "AdminUpdated"
            };
            _context.SpareParts.Add(sparePartName);
            _context.SaveChanges();

            return sparePartName;
        }

        public void AddSparePart(SparePartViewModel model)
        {
            var SparePartName = AddSparePartName(model.SparePartName);

            var SparePartQuanity = new SparePartQuantity
            {
                SparePartId = SparePartName.SparePartId,
                Quantity = model.SparePartQuantity,
                IsDeleted = false,
                QuantityLeft = model.SparePartQuantity,
                CreatedBy= SparePartName.CreatedBy,
                CreatedOn =SparePartName.CreatedOn,
                UpdatedOn =SparePartName.UpdatedOn,
                UpdatedBy = SparePartName.UpdatedBy

            };

            _context.SparePartQuantities.Add(SparePartQuanity);
            _context.SaveChanges();
        }

        public void EditSparePartName(SparePartViewModel sparepart)
        {
            SparePart sparePart = _context.SpareParts.Find(sparepart.SparePartId);

            if(sparePart!= null)
            {
                sparePart.SparePartName = sparepart.SparePartName;
                sparePart.UpdatedBy = "SpareAdmin";
                sparePart.UpdatedOn = DateTime.Now;

                _context.SpareParts.Update(sparePart);
                _context.SaveChanges();
            }
        }

        public void UpdateSpareQuantity(SparePartViewModel model)
        {

            SparePartQuantity sparePartQuantity = _context.SparePartQuantities.Where(x => x.SparePartId == model.SparePartId).FirstOrDefault();
            if(sparePartQuantity != null)
            {
                EditSparePartName(model);
                var SparePartQuanity = new SparePartQuantity
                {
                    SparePartId = model.SparePartId,
                    Quantity = (int)(model.SparePartQuantity + sparePartQuantity.QuantityLeft),
                    QuantityLeft = model.SparePartQuantity + sparePartQuantity.QuantityLeft,
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                 

                };

                _context.SparePartQuantities.Add(SparePartQuanity);
                _context.SaveChanges();

            }
        }
        public void DeleteSparePart(int sparePartId)
        {
            var sparePartQuantity = _context.SparePartQuantities.Where(x => x.SparePartId == sparePartId).ToList();
            if (sparePartQuantity.Count>0)
            {
                for (int i = 0; i < sparePartQuantity.Count; i++)
                {

                    sparePartQuantity[i].UpdatedBy = "DeleteAdmin";
                    sparePartQuantity[i].IsDeleted = true;
                    sparePartQuantity[i].UpdatedOn = DateTime.Now;
                  
                    _context.SparePartQuantities.Update(sparePartQuantity[i]);
                    _context.SaveChanges();
                }
               

               

            }
        }
        public void SubtractSparePartQuantityAfterRoutineMaintenanceActivity(RoutineActivityCheck Activity)
        {
            var res = GetSpareParts();

            List<SparePartQuantity> sparePartQuantities = new List<SparePartQuantity>();

            var number = res.Select(x => x.SparePartId).Distinct().ToList();/// Selecting only distinct Spare Part Id from the response(res)

            for (int i = 0; i < number.Count(); i++)
            {
                /////Selecting Current CreatedON which distinct Id////////// 
                sparePartQuantities.Add(res.OrderByDescending(x => x.CreatedOn).FirstOrDefault(x => x.SparePartId == number[i]));
                /////Selecting Current CreatedON which distinct Id////////// 

            }
            SparePartQuantity sparePartQuantity = sparePartQuantities.Where(x => x.SparePartId == Activity.SparePartId).FirstOrDefault();
            if (sparePartQuantity != null)
            {

                sparePartQuantity.QuantityLeft = (int?)(sparePartQuantity.QuantityLeft - Activity.Quantity);
                sparePartQuantity.UpdatedBy = "UpdatedRoutineAdmin";
                sparePartQuantity.UpdatedOn = DateTime.Now;

                _context.SparePartQuantities.Update(sparePartQuantity);
                _context.SaveChanges();

            }
        }
        public void AddSparePartQuantityAfterRoutineMaintenanceActivity(RoutineActivityCheck Activity)
        {
            var res = GetSpareParts();

            List<SparePartQuantity> sparePartQuantities = new List<SparePartQuantity>();

            var number = res.Select(x => x.SparePartId).Distinct().ToList();/// Selecting only distinct Spare Part Id from the response(res)

            for (int i = 0; i < number.Count(); i++)
            {
                /////Selecting Current CreatedON which distinct Id////////// 
                sparePartQuantities.Add(res.OrderByDescending(x => x.CreatedOn).FirstOrDefault(x => x.SparePartId == number[i]));
                /////Selecting Current CreatedON which distinct Id////////// 

            }
            SparePartQuantity sparePartQuantity = sparePartQuantities.Where(x => x.SparePartId == Activity.SparePartId).FirstOrDefault();
            if (sparePartQuantity != null)
            {

                sparePartQuantity.QuantityLeft = (int?)(sparePartQuantity.QuantityLeft + Activity.Quantity);
                sparePartQuantity.UpdatedBy = "UpdatedRoutineAdmin";
                sparePartQuantity.UpdatedOn = DateTime.Now;

                _context.SparePartQuantities.Update(sparePartQuantity);
                _context.SaveChanges();

            }
        }







        /////////////////////////Routine Activities//////////////////////
        ///
        public List<RoutineMaintenanceActivity> GetRoutineMaintenanceActivities()
        {
            return _context.RoutineMaintenanceActivities.Where(x => x.IsDeleted != true).ToList();
        }

        public void DeleteRoutineActivity(int RoutineActivityId)
        {
          var results=  _context.RoutineMaintenanceActivities.Where(x => x.RoutineMaintenanceActivityId == RoutineActivityId).FirstOrDefault();

            results.IsDeleted = true;
            results.UpdatedBy = "UpdatedAdmin";
            results.UpdatedOn = DateTime.Now;
            _context.RoutineMaintenanceActivities.Update(results);
            _context.SaveChanges();
        }

        public void EditRoutineActivity(RoutineMaintenanceActivity routineActivity)
        {
            var results = _context.RoutineMaintenanceActivities.Where(x => x.RoutineMaintenanceActivityId == routineActivity.RoutineMaintenanceActivityId).FirstOrDefault();

            if(results!= null)
            {
                results.ActivityName = routineActivity.ActivityName;
                results.UpdatedBy = "UpdatedAdmin";
                results.UpdatedOn = DateTime.Now;

                _context.RoutineMaintenanceActivities.Update(results);
                _context.SaveChanges();
            }
        }

        public void AddRoutineActivity(RoutineActivityViewModel model)
        {
            var routineActivity = new RoutineMaintenanceActivity()
            {
                ActivityName = model.RoutineActivityName,
                CreatedBy = "RoutineAdmin",
                CreatedOn = DateTime.Now,
                IsDeleted = false,
            };
            _context.RoutineMaintenanceActivities.Add(routineActivity);
            _context.SaveChanges();
        }
    }
}
