using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IBusHiringPricesRepository
    {
        public void saveBusHiringPrice(BusHiringPriceViewModel model);
        public List<BusHiringPrice> GetBusHiringPrice();

    }
}
