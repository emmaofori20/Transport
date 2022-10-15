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

        }
        public List<BusHiringPrice> GetBusHiringPrice()
        {
            return _context.BusHiringPrices.ToList();
        }
    }
}
