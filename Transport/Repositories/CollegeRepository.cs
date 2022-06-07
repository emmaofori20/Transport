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
    public class CollegeRepository : ICollegeRepository
    {
        private readonly TransportDbTestContext _context;

        public CollegeRepository(TransportDbTestContext context)
        {
            _context = context;
        }

        public SelectList GetColleges()
        {
         
            return new SelectList(_context.Colleges
                .Select(s=> new {Id = s.CollegeId, Text =$"{s.CollegeName}"}),"Id", "Text");
        }

    }
}
