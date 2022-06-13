using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly TransportDbTestContext _context;
        public CountryRepository(TransportDbTestContext context)
        {
            _context = context;
        }

        public SelectList GetAllCountries() 
        {
            return new SelectList(_context.Countries
               .Select(s => new { Id = s.CountryId, Text = $"{s.CountryName}" }), "Id", "Text");
        }
        
    }
}
