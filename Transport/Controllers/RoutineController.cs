﻿using Microsoft.AspNetCore.Mvc;
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
                bool check = model.VehicleId != 0 ? true : false; /// check if VehicleId is not zero
                var raw = routineService.routineMaintenanceVehicle();
                model.AllVehicles = raw.AllVehicles;
                model.RoutineActivity = raw.RoutineActivity;

                if (check)
                {
                    var isChecked = routineService.CheckRoutineMaintenanceVehicleSpareParts(model);
                    //to continue ischecked must be 
                    if (!isChecked)
                    {
                        var results = routineService.AddRoutineMaintenanceVehicle(model);

                        return RedirectToAction("ViewRoutineMaintenance", new { RoutineId = results.VehicleRoutineMaintenanceId });
                    }
                    
                    return View(model);
                }
                ViewBag.PageError = "Kindly select a vehicle";
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
            try
            {
                var results = routineService.ViewRoutineVehicleMaintenance(RoutineId);
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

        public IActionResult EditRoutineMaintenance(int RoutineId)
        {
            try
            {
                var results = routineService.ViewRoutineVehicleMaintenance(RoutineId);
                
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
        public IActionResult EditRoutineMaintenance(RoutineMaintenanceVehicleViewModel model,int RoutineId)
        {
            try
            {
                bool check = model.VehicleId != 0 ? true : false; /// check if VehicleId is not zero
                if (check)
                {
                    routineService.EditRoutineMaintenanceVehicle(model);

                    return RedirectToAction("ViewRoutineMaintenance", new { RoutineId = model.RoutineId});
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

        public IActionResult DeleteRoutineMaintenance(int RoutineId)
        {
            try
            {
                routineService.DeleteRoutineMaintenanceVehicle(RoutineId);
                return RedirectToAction("Index","Request");
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
