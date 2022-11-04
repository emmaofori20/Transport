using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IDepartmentRepository
    {
        public List<DepartmentViewModel> AllDepartments();
        public SelectList GetAllDepartmentsByCollegeId(int CollegeId);
    }
}
