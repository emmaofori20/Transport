using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class RoutineMaintenanceActivityRepository : IRoutineMaintenanceActivityRepository
    {
        private readonly TransportDbContext _context;

        public RoutineMaintenanceActivityRepository(TransportDbContext context)
        {
            this._context = context;
        }
        public List<RoutineMaintenanceActivity> GetAllActivity()
        {
            return _context.RoutineMaintenanceActivities.ToList();
        }
    }
}
