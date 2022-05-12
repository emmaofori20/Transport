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
        public async Task<ViewResult> VehicleList()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVehicles();
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

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewVehicle(AddVehicleViewModel vehicleModel)
        {
            var results = _vehicleService.setAllList();

            try
            {

                

                if (vehicleModel.PhotoFiles != null)
                {
                    //string folder = "photos/vehicle/";

                    vehicleModel.Photos = new List<VehiclePhoto>();

                    foreach (var file in vehicleModel.PhotoFiles)
                    {
                        var photo = new VehiclePhoto()
                        {
                            PhotoName = file.FileName,
                            PhotoFile = UploadImage(file),
                        };

                        vehicleModel.Photos.Add(photo);
                    }
                }

                var result = await _vehicleService.AddNewVehicle(vehicleModel);

                return RedirectToAction(nameof(VehicleList));
            }
            catch
            {
                return View();
            }

        }

        // GET: VehicleController/Edit/5
        public async Task<IActionResult> UpdateVehicle(int Id)
        {
            var results = _vehicleService.setAllList();

            ViewBag.Colleges = results.Colleges;
            ViewBag.Departments= results.Departments;
            ViewBag.Makes = results.Makes;
            ViewBag.Insurances = results.Insurances;
            ViewBag.Statuses = results.Statuses;
            ViewBag.UseOfVehicle = results.VehicleUses;
            try
            {
                var result = await _vehicleService.GetVehicleToUpdate(Id);
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
            try
            {

                    if (UpdateModel.PhotoFiles != null)
                    {
                    //string folder = "photos/vehicle/";

                    UpdateModel.Photos = new List<VehiclePhoto>();


                    foreach (var file in UpdateModel.PhotoFiles)
                        {
                            var gallery = new VehiclePhoto()
                            {
                                PhotoName = file.FileName,
                                PhotoFile = UploadImage(file),
                            };

                            UpdateModel.Photos.Add(gallery);
                        }

                    }

                    var resultId = await _vehicleService.UpdateVehicle(UpdateModel);

                    return RedirectToAction(nameof(VehicleList));
                    //if (vehicleId > 0)
                    //{
                    //    return RedirectToAction(nameof(GetVehicleDetails), new { isSuccess = true, Id = Id });
                    //}
                
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
        //private async Task<string> UploadImage(string folderPath, IFormFile file)
        //{
        //    folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

        //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

        //    await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        //    return "/" + folderPath;
        //}
        private byte[] UploadImage(IFormFile formFile)
        {
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                fileBytes = stream.ToArray();
            }

            return fileBytes;
        }
    }
}
