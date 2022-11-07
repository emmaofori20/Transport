using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class HrStaffViewModel
    {
        public byte[] Photo { get; set; }
        public int StaffId { get; set; }
        public string StaffId2 { get; set; }
        public string Surname { get; set; }
        public string Othername { get; set; }
        public string PrimaryPhone { get; set; }
        public string Techmail { get; set; }
        public string CurrentDepartment { get; set; }
        public bool IsActive { get; set; }

    }
}
