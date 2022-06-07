using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class ColourRepository : IColourRepository
    {
        private readonly TransportDbTestContext _context;
        public ColourRepository(TransportDbTestContext context)
        {
            _context = context;
        }

        public SelectList GetColours()
        {
            return new SelectList( _context.Colours
               .Select(s => new { Id = s.ColourId, Text = $"{s.ColourName}" }), "Id", "Text");
        }
    }
}
