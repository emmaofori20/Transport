using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class VehicleTypeForHireRepository: IVehicleTypeForHireRepository
    {
        private readonly TransportDbContext _context;
        public VehicleTypeForHireRepository(TransportDbContext context)
        {
            _context = context;

        }

        public List<VehicleTypeForHire> GetVehicleTypeForHire()
        {
            return _context.VehicleTypeForHires.ToList();
        }
    }
}
