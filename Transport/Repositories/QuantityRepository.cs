using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class QuantityRepository : IQuantityRepository
    {
        private readonly TransportDbContext _context;

        public QuantityRepository(TransportDbContext context )
        {
            _context = context;
        }

        public SelectList GetAllQuantities() 
        {
            return new SelectList(_context.Quantities
                .Select(x => new { Id = x.QuantityId, Text = $"{x.Number}" }).ToList(), "Id", "Text");
        }
    }
}
