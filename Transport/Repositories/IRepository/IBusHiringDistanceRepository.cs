using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.Repositories.IRepository
{
    public interface IBusHiringDistanceRepository
    {
        public List<BusHiringDistance> GetBusHiringDistance();
    }
}
