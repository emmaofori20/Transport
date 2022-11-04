using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
   public interface IAdminService
    {
        public AdminAndUserViewModel GetAllTransportStaff();
        public void AddNewUser(AddUserViewModel model);
        public HrStaffViewModel VerifyStaffId(string StaffId);
        public void ToggleStaffActive(int StaffId, string Issuer);

    }
}

