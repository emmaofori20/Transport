using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models;
using Transport.Models.Data;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Controllers
{
    [Authorize(Policy = "CustomAuthorization")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VehicleController(
            IVehicleService vehicleService,
            IWebHostEnvironment webHostEnvironment

            )
        {
            _vehicleService = vehicleService;
            _webHostEnvironment = webHostEnvironment;

        }
        // GET: VehicleController
        public ViewResult VehicleList()
        {
            try
            {
                var vehicles = _vehicleService.GetAllVehicles();
                return View(vehicles);
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

        // GET: VehicleController/Details/5
        public async Task<ViewResult> GetVehicleDetails(int Id)
        {
            try
            {
                var result = await _vehicleService.GetVehicleById(Id);
                return View(result);
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


        // GET: VehicleController/Create
        public IActionResult AddNewVehicle()
        {
            var results = _vehicleService.setAllList();
           
            return View(results);
        }


        [HttpGet]
        public IActionResult GetModelsByMake(int MakeId)
        {
            var results = _vehicleService.listOfModelsByMake(MakeId);

            return Json(results.Models);
        }


       [HttpGet]
       public IActionResult GetDepartmentsByCollege(int CollegeId)
        {
            var results = _vehicleService.listOfDepartmentsByCollege(CollegeId);
            return Json(results.Departments);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewVehicle(AddVehicleViewModel vehicleModel)

        {
            //var results = _vehicleService.setAllList();


            try
            {

                var result = await _vehicleService.AddNewVehicle(vehicleModel);


                return RedirectToAction(nameof(GetVehicleDetails), new { Id = result });
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

        // GET: VehicleController/Edit/5
        public async Task<IActionResult> UpdateVehicle(int Id)
        {

            var results = _vehicleService.setAllList();
            ViewBag.Colleges = results.Colleges;
            ViewBag.Makes = results.Makes;
            ViewBag.Insurances = results.Insurances;
            ViewBag.Statuses = results.Statuses;
            ViewBag.UseOfVehicle = results.VehicleUses;
            ViewBag.TyreSizes = results.TyreSizes;
            ViewBag.Countries = results.Countries;

            ViewBag.VehicleTypes = results.VehicleTypes;
            ViewBag.FuelTypes = results.FuelTypes;
            ViewBag.Colours = results.Colours;
            ViewBag.Quantities = results.Quantities;
            ViewBag.TransmissionTypes = results.TransmissionTypes;
            ViewBag.PermAxleLoads = results.PermAxleLoads;
            ViewBag.PhotoSections = results.PhotoSections;

            try
            {
                var result = await _vehicleService.GetVehicleToUpdate(Id);
                var models = _vehicleService.listOfModelsByMake(result.MakeId).Models;
                var departments = _vehicleService.listOfDepartmentsByCollege(result.CollegeId).Departments;
                ViewBag.Models = models;
                ViewBag.Departments = departments;
                return View(result);
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

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVehicle(UpdateVehicleViewModel UpdateModel)
        {
            var results = _vehicleService.setAllList();
            ViewBag.Colleges = results.Colleges;
            ViewBag.Departments = results.Departments;
            ViewBag.Makes = results.Makes;
            ViewBag.Insurances = results.Insurances;
            ViewBag.Statuses = results.Statuses;
            ViewBag.UseOfVehicle = results.VehicleUses;
            ViewBag.TyreSizes = results.TyreSizes;
            ViewBag.Countries = results.Countries;
            ViewBag.Models = results.Models;
            ViewBag.VehicleTypes = results.VehicleTypes;
            ViewBag.FuelTypes = results.FuelTypes;
            ViewBag.Colours = results.Colours;
            ViewBag.Quantities = results.Quantities;
            ViewBag.TransmissionTypes = results.TransmissionTypes;
            ViewBag.PermAxleLoads = results.PermAxleLoads;
            ViewBag.PhotoSections = results.PhotoSections;


            try
            {

                var resultId = await _vehicleService.UpdateVehicle(UpdateModel);

                return RedirectToAction(nameof(GetVehicleDetails), new { Id = resultId });
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

        //Delete A Vehicle
        public IActionResult DeleteVehicle(int Id)
        {
            try
            {
                _vehicleService.DeleteVehicle(Id);
                return RedirectToAction("VehicleList");
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


    }
}
