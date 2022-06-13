using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class PermAxleLoadRepository : IPermAxleLoadRepository
    {
        private readonly TransportDbContext _context;
        public PermAxleLoadRepository(TransportDbContext context)
        {
            _context = context;
        }

        public SelectList GetPermAxleLoads()
        {
            return new SelectList(_context.PermAxleLoads
               .Select(s => new { Id = s.PermAxleLoadId, Text = $"{s.PermAxleLoadValue}" }), "Id", "Text");
        }
    }
}
