using Microsoft.AspNetCore.Authorization;
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
    [SessionExist]
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
                results.CreatedBy = GetCurrentUserName().Value;
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
                model.SparePartsUsed = raw.SparePartsUsed;
                model.CreatedBy = GetCurrentUserName().Value; // Getting Issuer Name

                if (check)
                {
                    var isChecked = routineService.CheckRoutineMaintenanceVehicleSpareParts(model);
                    //to continue ischecked must be 
                    if (!isChecked)
                    {
                        var results = routineService.AddRoutineMaintenanceVehicle(model);
                        return RedirectToAction("ViewRoutineMaintenance", new { RoutineId = results.VehicleRoutineMaintenanceId });
                    }
                    ViewBag.SparePartError = "Spare parts to be used is more than spare parts left in the inventory ";
                    return View(model);
                }
                ViewBag.PageError = "Kindly select a vehicle";
                model = raw;
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
        public Claim GetCurrentUserName()
        {
            return User.Identities
                       .FirstOrDefault()
                       .Claims.Where(x => x.Type == ClaimsEnum.Name.ToString().ToLower())
                       .FirstOrDefault();
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
                model.CreatedBy = GetCurrentUserName().Value;// Getting Issuers name
                bool check = model.VehicleId != 0 ? true : false; // check if VehicleId is not zero
                if (check)
                {
                    //second check to monito sparepart quantities
                    bool SparepartQuantity = routineService.CheckSparePartQuanityBeforeEdit(model);
                    if (!SparepartQuantity)
                    {
                        routineService.SubstractAndAddSparePartQuantity(model);
                        routineService.EditRoutineMaintenanceVehicle(model);
                        return RedirectToAction("ViewRoutineMaintenance", new { RoutineId = model.RoutineId });
                    }
                    ViewBag.SparePartError = "Spare parts used is more than spare parts left in the inventory ";
                    return View(model);
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
                var issuer = GetCurrentUserName().Value;
                routineService.DeleteRoutineMaintenanceVehicle(RoutineId, issuer);
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
