using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IHirerRepository _hirerRepository;
        private readonly IVehicleMaintenanceRequestRepository _vehicleMaintenanceRequestRepository;

        

        public AdminService(
            ITransportStaffRepository transportStaffRepository,
            IVehicleRepository vehicleRepository,
            IHirerRepository hirerRepository,
            IVehicleMaintenanceRequestRepository vehicleMaintenanceRequestRepository)
        {
            _transportStaffRepository = transportStaffRepository;
            _vehicleRepository = vehicleRepository;
            _hirerRepository = hirerRepository;
            _vehicleMaintenanceRequestRepository = vehicleMaintenanceRequestRepository;
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

        public List<TransportStaffViewModel> GetTransportStaff()
        {
            return _transportStaffRepository.GetAllTransportStaff();
        }

        public void UpdateTransportStaffTable()
        {
            _transportStaffRepository.UpdateTransportStaffTable();
        }

        public void ToggleStaffActive(int StaffId, string Issuer)
        {
            _transportStaffRepository.ToggleStaffActive(StaffId, Issuer);
        }

        public SelectList GetAllRoles()
        {
            return new SelectList(_transportStaffRepository.GetAllRoles()
               .Select(s => new { Id = s.RoleId, Text = $"{s.RoleName}" }), "Id", "Text");
        }

        public  DashboardViewModel GetItemsForDashboard()
        {
            var dashboardVM = new DashboardViewModel
            {
                TotalVehicleNumber = _vehicleRepository.GetTotalVehicleNumber(),
                TotalUsersNumber = _transportStaffRepository.GetUsersTotalNumber(),
                TotalNumberOfNewHiringRequests = _hirerRepository.GetNewHiringRequestCount(),
                TotalNumberOfNewMaintenanceRequests = _vehicleMaintenanceRequestRepository.GetNewMaintenanceRequestCount(),

            };

            return dashboardVM;
        }

        public List<TransportStaffDetailViewModel> GetTransportStaffDetail(string staffId)
        {
            return _transportStaffRepository.GetTransportStaffDetail(staffId);
        }
    }
}
