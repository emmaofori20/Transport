using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.Services.IServices;
using Transport.Utils;
using Transport.ViewModels;

namespace Transport.Services
{
    public class AdminService: IAdminService
    {
        private readonly ITransportStaffRepository _transportStaffRepository;

        public AdminService(ITransportStaffRepository transportStaffRepository )
        {
            _transportStaffRepository = transportStaffRepository;
        }
        public AdminAndUserViewModel GetAllTransportStaff()
        {
            return _transportStaffRepository.GetAllUsers();
        }
        public void AddNewUser(AddUserViewModel model)
        {
            _transportStaffRepository.AddNewUser(model);
        }


        public HrStaffViewModel VerifyStaffId(string StaffId)
        {
            return _transportStaffRepository.VerifyStaffId(StaffId);

        }

        public void ToggleStaffActive(int StaffId, string Issuer)
        {
            _transportStaffRepository.ToggleStaffActive(StaffId, Issuer);
        }
    }
}
