using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Transport.Models;
using Transport.Services.IServices;
using Transport.Utils;
using Transport.ViewModels;

namespace Transport.Controllers
{
    [Authorize(Policy = "CustomAuthorization")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        // GET: AdministratorController
        
        public IActionResult Index()
        {
            ViewBag.AllRoles = _adminService.GetAllRoles();
            var result = _adminService.GetAllTransportStaff();     
            return View(result);
        }

        [HttpPost]
        public IActionResult AddNewUser(AddUserViewModel model)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = GetCurrentUserName().ToString();
                    _adminService.AddNewUser(model);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel()
                {
                    RequestId = ex.Message
                };

                return View("Error", errorViewModel);
            }
        }


        public IActionResult VerifyStaffId(string StaffId)
        {
            var staffDetails = _adminService.VerifyStaffId(StaffId);
            return Json(staffDetails);
        }

        public Claim GetCurrentUserName()
        {
            return User.Identities
                       .FirstOrDefault()
                       .Claims.Where(x => x.Type == ClaimsEnum.Name.ToString().ToLower())
                       .FirstOrDefault();
        }
        public void ToggleStaffIsActive(int StaffId)
        {
            _adminService.ToggleStaffActive(StaffId, GetCurrentUserName().ToString());
        }
    }
}
