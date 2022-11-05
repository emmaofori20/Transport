using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public class BusHiringPricesRepository: IBusHiringPricesRepository
    {
        private readonly TransportDbContext _context;

        public BusHiringPricesRepository(TransportDbContext context)
        {
            _context = context;
        }

        public void saveBusHiringPrice(BusHiringPriceViewModel model)
        {
            var res = _context.BusHiringPrices.Find(model.BusHirngPriceId);
            if (res != null && res.Price != model.Price)
            {
                res.IsActive = false;
                res.UpdatedBy = "Admin";
                res.UpdatedOn = DateTime.Now;
                _context.BusHiringPrices.Update(res);
                _context.SaveChanges();
                SaveNewBusHiringPriceData(model);

            }
            else if(res == null && model.Price > 0)
            {

                SaveNewBusHiringPriceData(model);

            }


        }

        private void SaveNewBusHiringPriceData(BusHiringPriceViewModel model)
        {
            var BusHiringPrice = new BusHiringPrice()
            {
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                Price = model.Price,
                BusHiringDistanceId = model.BusHiringDistanceId,
                VehicleTypeForHireId = model.VehicleTypeForHireId,
                IsActive = true
            };
            _context.BusHiringPrices.Add(BusHiringPrice);
            _context.SaveChanges();
        }

        public List<BusHiringPrice> GetBusHiringPrice()
        {
            return _context.BusHiringPrices.Where(x=>x.IsActive == true).ToList();
        }
    }
}
