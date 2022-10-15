using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class BusHiringDistanceRepository: IBusHiringDistanceRepository
    {
        private readonly TransportDbContext _context;

        public BusHiringDistanceRepository(TransportDbContext context)
        {
            _context = context;
        }

        public List<BusHiringDistance> GetBusHiringDistance()
        {
            return _context.BusHiringDistances.ToList();
        }
    }
}
