using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{

   
    public class TyreSizeRepository : ITyreSizeRepository
    {
        private readonly TransportDbTestContext _context;
        public TyreSizeRepository(TransportDbTestContext context)
        {
            _context = context;
        }
        public SelectList GetTyreSizes()
        {
            return new SelectList(_context.TyreSizes
                .Select(x => new { Id = x.TyreSizeId, Text = $"{x.TyreSizeNumber}" }).ToList(), "Id", "Text");
        }
    }
}
