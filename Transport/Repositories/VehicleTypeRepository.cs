using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{

    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly TransportDbContext _context;
        public VehicleTypeRepository(TransportDbContext context)
        {
            _context = context;
        }

        public SelectList GetVehicleTypes() 
        {
            return new SelectList(_context.VehicleTypes
               .Select(s => new { Id = s.VehicleTypeId, Text = $"{s.VehicleTypeName}" }), "Id", "Text");
        }
    }
}
