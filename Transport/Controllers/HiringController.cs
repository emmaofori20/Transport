using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Controllers
{
    public class HiringController : Controller
    {
        private readonly IHiringService hiringService;

        public HiringController(IHiringService hiringService)
        {
            this.hiringService = hiringService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HireBus()
        {
            var res = hiringService.SetVehiclesForHire();
            return View(res);
        }
        
        [HttpPost]
        public IActionResult HireBus(HireDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    hiringService.SetHireBus(model);
                    return RedirectToAction("HiringDetailsConfirmation");
                }
                return View(model);
            }
            catch (Exception err)
            {
                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return View("Error", error);
            }
        }

        public IActionResult HiringDetailsConfirmation()
        {
            return View();
        }

        public IActionResult HiringDashboard()
        {
            try
            {
                var res = hiringService.GetAllHirers();
                return View(res);
            }
            catch (Exception err)
            {
                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return View("Error", error);
            }
           
        }

        public IActionResult ViewHiringDetails(int HirerId)
        {
            try
            {
                var res = hiringService.GetSingleHireDetails(HirerId);
                return View(res);

            }
            catch (Exception err)
            {
                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return View("Error", error);

            }
        }

        [HttpPost]
        public IActionResult ProceedToApproveHire(List<ApproveHireRequest> requests)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    hiringService.ApproveHireRequest(requests);
                    return RedirectToAction(" HiringDashboard");
                }
                return View();
            }
            catch (Exception err)
            {
                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return View("Error", error);
            }
        }
    }
}
