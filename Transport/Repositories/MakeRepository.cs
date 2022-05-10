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
    public class MakeRepository : IMakeRepository
    {
        private readonly TransportDbContext _context;

        public MakeRepository(TransportDbContext context)
        {
            _context = context;
        }

        public SelectList GetAllMake()
        {
            return new SelectList(_context.Makes
               .Select(s => new { Id = s.MakeId, Text = $"{s.MakeName}" }), "Id", "Text");
        }
    }
}
