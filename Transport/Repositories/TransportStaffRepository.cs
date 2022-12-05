using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;
using Transport.Utils;
using Microsoft.EntityFrameworkCore;

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
            List<ApplicationUser> applicationUsers = _context.ApplicationUsers.Include(x => x.ApplicationUserRoles).ToList();

            AdminAndUserViewModel adminAndUserVM = new();
            adminAndUserVM.AllUsers = applicationUsers;

            return adminAndUserVM;
           
        }

        public int GetUsersTotalNumber()
        {
           return _context.ApplicationUsers.Count();
        }

        public void AssignRole(ApplicationUser model, int RoleId)
        {
            _context.ApplicationUserRoles.Add(new ApplicationUserRole
            {
                ApplicationUserId = model.ApplicationUserId,
                RoleId = RoleId 
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
                CreatedBy = model.CreatedBy,
            };

            _context.ApplicationUsers.Add(newUser);
            _context.SaveChanges();

            AssignRole(newUser,model.RoleId);
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

        public List<TransportStaff> GetAllTransportStaffDrivers()
        {
            return _context.TransportStaffs.Where(x => x.Rank.Contains("Driver")).ToList();
        }
        
        public List<TransportStaffViewModel> GetAllTransportStaff()
        {
            var result = _context.LoadStoredProc("sp_GetAllTransportStaff")
               .ExecuteStoredProc<TransportStaffViewModel>().ToList();

            return result;
        }
        
        public List<TransportStaffDetailViewModel> GetTransportStaffDetail(string staffId)
        {
            var result = _context.LoadStoredProc("sp_GetTransportStaffDetail")
             .WithSqlParam("StaffId", staffId)
             .ExecuteStoredProc<TransportStaffDetailViewModel>().ToList();

            return result;
        }
        public void UpdateTransportStaffTable()
        {
            var updatedTransportStaffList = GetAllTransportStaff();
            var oldTransportStaffList = _context.TransportStaffs.ToList();
            foreach (var item in updatedTransportStaffList)
            {
                var existingRecord = oldTransportStaffList.Where(x => x.StaffId == item.StaffID).FirstOrDefault();
                bool recordExists = existingRecord == null;
                if (!recordExists)
                {
                    var OldStaffDetails = oldTransportStaffList.Where(x => x.StaffId == item.StaffID).FirstOrDefault();
                    var NewStaffDetails = item;
                    UpdateTransportStaffTableWithNewDetails(OldStaffDetails, NewStaffDetails);
                }
                else
                {
                    AddNewTransportStaff(item);
                }
            }
        }

        public void AddNewTransportStaff(TransportStaffViewModel transportStaff)
        {
            _context.TransportStaffs.Add(new TransportStaff()
            {
                StaffId = transportStaff.StaffID,
                StaffId2 = transportStaff.StaffID2,
                Rank = transportStaff.RANK,
                DateOfBirth = transportStaff.DATEOFBIRTH,
                Surname = transportStaff.SURNAME,
                Othernames = transportStaff.OTHERNAME,
                TechMail = transportStaff.TECHMAIL,
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
            }) ;
            _context.SaveChanges();
        }

        public void UpdateTransportStaffTableWithNewDetails(TransportStaff oldStaffDetails, TransportStaffViewModel newstaffDetails)
        {
            oldStaffDetails.Othernames = newstaffDetails.OTHERNAME;
            oldStaffDetails.Surname = newstaffDetails.SURNAME;
            oldStaffDetails.TechMail = newstaffDetails.TECHMAIL;
            oldStaffDetails.Rank = newstaffDetails.RANK;
            oldStaffDetails.DateOfBirth = newstaffDetails.DATEOFBIRTH;
            
            _context.TransportStaffs.Update(oldStaffDetails);
            _context.SaveChanges();
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

        public List<Role> GetAllRoles()
        {
           return _context.Roles.ToList();
        }

    }
}
