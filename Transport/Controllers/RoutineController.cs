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
    public class RoutineController : Controller
    {
        private readonly IRoutineService routineService;

        public RoutineController(IRoutineService routineService)
        {
            this.routineService = routineService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectVehicleForRoutineMaintenance()
        {
            try
            {
                var results = routineService.routineMaintenanceVehicle();
                return View(results);
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
        public IActionResult SelectVehicleForRoutineMaintenance(RoutineMaintenanceVehicleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    routineService.AddRoutineMaintenanceVehicle(model);

                    RedirectToAction("Index", "Request");
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
        
        public IActionResult ViewRoutineMaintenance(int RoutineId)
        {
            var results = routineService.ViewRoutineVehicleMaintenance(RoutineId);
            return View(results);
        }

    }
}
