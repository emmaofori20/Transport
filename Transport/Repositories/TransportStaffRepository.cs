using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;
using Transport.Utils;

namespace Transport.Repositories
{
    public class TransportStaffRepository : ITransportStaffRepository
    {
        private readonly TransportDbContext _context;

        public TransportStaffRepository(TransportDbContext context)
        {
            _context = context;
        }
        

        public AdminAndUserViewModel GetAllUsers()
        {
            List<ApplicationUser> applicationUsers = _context.ApplicationUsers.ToList();

            AdminAndUserViewModel adminAndUserVM = new();

            adminAndUserVM.AllAdmins = applicationUsers;

            return adminAndUserVM;
           
        }

        public void AssignRole(ApplicationUser model)
        {
            _context.ApplicationUserRoles.Add(new ApplicationUserRole
            {
                //Add condition for different roles later
                ApplicationUserId = model.ApplicationUserId,
                RoleId = 1 
            });

            _context.SaveChanges();
        }

        public void AddNewUser(AddUserViewModel model)
        {

            var newUser = new ApplicationUser()
            {
                UserName = model.UserName,
                OtherNames = model.OtherName,
                SurName = model.SurName,
                IsActive = true,
                CreatedOn = DateTime.Now,
                StaffId = model.StaffId,
                CreatedBy = model.CreatedBy
            };
            _context.ApplicationUsers.Add(newUser);
            _context.SaveChanges();

            AssignRole(newUser);
        }

        public HrStaffViewModel GetStaffById(string staffId)
        {
            var result = _context.LoadStoredProc("sp_StaffDataGetByStaffId")
               .WithSqlParam("StaffId", staffId)
               .ExecuteStoredProc<HrStaffViewModel>().Single();

            return result;
        }

        public ApplicationUser GetUser(TicketReceivedContext context)
        {
            var username = context.Principal.Claims.Where(x => x.Type.ToLower() == ClaimsEnum.Name.ToString().ToLower())
                .FirstOrDefault().Value;

            var user = _context.ApplicationUsers.Where(x => x.UserName == username && x.IsActive).FirstOrDefault();

            return user;
        }

        public HrStaffViewModel VerifyStaffId(string StaffId)
        {
            return GetStaffById(StaffId);

        }

        public void ToggleStaffActive(int StaffId, string Issuer)
        {
            var staff = _context.ApplicationUsers
                 .Where(x => x.StaffId == StaffId)
                 .FirstOrDefault();
            staff.IsActive = !staff.IsActive;
            staff.UpdatedBy = Issuer;
            staff.UpdatedOn = DateTime.Now;

            _context.Update(staff);
            _context.SaveChanges();
        }

        public List<TransportStaff> GetAllTransportStaff()
        {
            return _context.TransportStaffs.ToList();
        }

    }
}
