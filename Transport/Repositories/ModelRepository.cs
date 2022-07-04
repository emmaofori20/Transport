using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly TransportDbContext _context;
        public ModelRepository(TransportDbContext context)
        {
            _context = context;
        }

        public SelectList GetAllModels() 
        {
            return new SelectList(_context.Models
                            .Select(s => new { Id = s.ModelId, Text = $"{s.ModelName}" }), "Id", "Text");

        }
    }
}
