using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class TransmissionTypeRepository : ITransmissionTypeRepository
    {
        private readonly TransportDbContext _context;
        public TransmissionTypeRepository(TransportDbContext context)
        {
            _context = context;
        }

        public SelectList GetTransmissionTypes()
        {
            return new SelectList(_context.TransmissionTypes
               .Select(s => new { Id = s.TransmissionTypeId, Text = $"{s.TransmissionTypeName}" }), "Id", "Text");
        }
    }
}
