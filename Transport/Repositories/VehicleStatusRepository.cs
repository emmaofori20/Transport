using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;

namespace Transport.Repositories
{
    public class VehicleStatusRepository : IVehicleStatusRepository
    {
        private readonly TransportDbContext _context;

        public VehicleStatusRepository(TransportDbContext context)
        {
            _context = context;
        }

        public SelectList GetAllVehicleStatuses()
        {
            return new SelectList(_context.Statuses
               .Select(s => new { Id = s.StatusId, Text = $"{s.StatusName}" }), "Id", "Text");
        }
    }
}
