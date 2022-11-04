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
        private readonly TransportDbContext _context;

        public DepartmentRepository(TransportDbContext context)
        {
            _context = context;
        }

        public List<DepartmentViewModel> AllDepartments()
        {
            List<DepartmentViewModel> allDepartments = new List<DepartmentViewModel>();
            allDepartments = _context.Departments.Select(x => new DepartmentViewModel()
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                CollegeId = x.CollegeId
            }).ToList();

            return allDepartments;
            
        }

        public SelectList GetAllDepartmentsByCollegeId(int CollegeId)
        {
            List<DepartmentViewModel> ListOfDepartmentsByCollege = new List<DepartmentViewModel>();
            ListOfDepartmentsByCollege = AllDepartments().Where(x => x.CollegeId == CollegeId).ToList();
            SelectList departmentsByCollege = new SelectList(ListOfDepartmentsByCollege, "DepartmentId", "DepartmentName",0);
            return departmentsByCollege;
        }

    }
}
