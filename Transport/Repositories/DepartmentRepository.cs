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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TransportDbTestContext _context;

        public DepartmentRepository(TransportDbTestContext context)
        {
            _context = context;
        }

        public SelectList GetDepartments()
        {
            
            return new SelectList(_context.Departments
                .Select(s => new { Id = s.DepartmentId, Text = $"{s.DepartmentName}" }), "Id", "Text");
            
        }

    }
}
