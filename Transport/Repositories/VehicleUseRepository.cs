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
    public class VehicleUseRepository : IVehicleUseRepository
    {
        private readonly TransportDbTestContext _context;

        public VehicleUseRepository(TransportDbTestContext context)
        {
            _context = context;
        }

        public SelectList GetAllVehicleUse()
        {
            return new SelectList(_context.VehicleUses
               .Select(s => new { Id = s.VehicleUseId, Text = $"{s.UseName}" }), "Id", "Text");
        }
    }
}
