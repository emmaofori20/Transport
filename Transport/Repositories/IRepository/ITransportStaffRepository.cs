using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface ITransportStaffRepository
    {
        public void AssignRole(ApplicationUser model, int RoleId);
        public void AddNewUser(AddUserViewModel model);
        public AdminAndUserViewModel GetAllUsers();
        public int GetUsersTotalNumber();
        public ApplicationUser GetUser(TicketReceivedContext context);
        public HrStaffViewModel VerifyStaffId(string StaffId);

        public void ToggleStaffActive(int StaffId, string Issuer);
        public List<Role> GetAllRoles();
    }
}
