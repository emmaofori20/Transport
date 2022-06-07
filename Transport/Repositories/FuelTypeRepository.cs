using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly TransportDbTestContext _context;
        public FuelTypeRepository(TransportDbTestContext context)
        {
            _context = context;
        }
        public SelectList GetAllFuelTypes()
        {
            return new SelectList(_context.FuelTypes
               .Select(s => new { Id = s.FuelTypeId, Text = $"{s.FuelTypeName}" }), "Id", "Text");
        }
    }
}
