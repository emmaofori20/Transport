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
                    Quantity = model.SparePartQuantity,
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                 

                };

                _context.SparePartQuantities.Update(SparePartQuanity);
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
