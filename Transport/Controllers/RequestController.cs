using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models;
using Transport.Services.IServices;
using Transport.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Transport.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Transport.Utils;
using System.Globalization;

namespace Transport.Controllers
{
    [Authorize(Policy = "CustomAuthorization")]
    public class RequestController : Controller
    {
        public IRequestService requestService;
        private readonly IVehicleService vehicleService;
        private readonly IRoutineService routineService;
        private readonly IRequestTypeRepository requestTypeRepository;

        //CONSTRUCTOR
        public RequestController(IRequestService _requestService, IVehicleService vehicleService,
                IRoutineService routineService,
                IRequestTypeRepository requestTypeRepository)
        {
            requestService = _requestService;
            this.vehicleService = vehicleService;
            this.routineService = routineService;
            this.requestTypeRepository = requestTypeRepository;
        }
        public IActionResult Index()
        {
            try
            {

                List<VehicleMaintenanceRequestsViewModel> results = requestService.GetAllVehicleMaintenanceRequest().Item1;
                var routineMaintenances = routineService.GetVehicleRoutineMaintenances();
                var data = new RequestVehicleViewModel
                {
                    VehicleMaintenanceRequests = results,
                    VehicleRoutineMaintenanceRequest =routineMaintenances,
                    AllVehicles = new SelectList(requestService
                                                    .GetAllVehicleMaintenanceRequest().Item2
                                                    .Select(s=> new { VehicleId = s.VehicleId, RegistrationNumber = $"{s.RegistrationNumber}", ChasisNumber = $"{s.ChasisNumber}"}), "VehicleId", "RegistrationNumber", "ChasisNumber")
                };
                return View(data);

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
        public IActionResult MakeRequestMaintainance(RequestVehicleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Getting issuer's name
                    var Issuer = GetCurrentUserName().Value;
                    model.requestMaintenance.CreatedBy = Issuer;
                    //Making a Request Maintnace
                    var result = requestService.MakeRequestMaintenance(model.requestMaintenance);
                    return RedirectToAction("RequestSparePart", new { Id = result.VehicleMaintenanceRequestId });
                }
                else
                {
                    return RedirectToAction("Index");
                }
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


        [HttpGet]
        public IActionResult RequestSparePart(int Id)
        {
            ViewBag.Requestitem = new SelectList(requestTypeRepository.GetAllRequestType()
                .Select(s => new { Id = s.RequestTypeId, Text = $"{s.RequestTypeName}" }), "Id", "Text");
            ViewData["RequestSparePartId"] = Id;
            return View();
        }

        [HttpPost]
        public IActionResult RequestSparePart(List<VehicleMaintananceSparepartViewModel> model, int Id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //Getting issuer's name
                    var Issuer = GetCurrentUserName().Value;
                    //returns true after method is completed
                    requestService.AddRequestSparePart(model, Id, Issuer);
                    return RedirectToAction("RequestSparePartDetails", new { ListId = Id });
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

        public IActionResult RequestSparePartDetails(int ListId)
        {
            try
            {
                ViewData["RequestListId"] = ListId;
                var results = requestService.VehicleMaintenanceRequestDetails(ListId);
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

        public IActionResult DeleteRequestMaintenance(int RequestId)
        {
            try
            {
                //Getting issuer's name
                var Issuer = GetCurrentUserName().Value;
                requestService.DeleteVehicleRequestMaintenance(RequestId, Issuer);
                return RedirectToAction("Index");

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

        public IActionResult EditRequestMaintenance(int RequestId)
        {
            try
            {
                ViewData["EditRequestListId"] = RequestId;
                ViewBag.Requestitem = new SelectList(requestTypeRepository.GetAllRequestType()
                .Select(s => new { Id = s.RequestTypeId, Text = $"{s.RequestTypeName}" }), "Id", "Text");

                var results = requestService.VehicleMaintenanceRequestDetails(RequestId);
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
        public IActionResult EditRequestMaintenance(VehicleMaintenanceRequestDetailsViewModel model, int RequestId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Getting issuer's name
                    var Issuer = GetCurrentUserName().Value;
                    requestService.EdiVehicleRequestMaintenance(model, RequestId, Issuer);
                    return RedirectToAction("RequestSparePartDetails", new { ListId = RequestId });
                }
                //ViewData["EditRequestListId"] = RequestId;
                // var results = requestService.VehicleMaintenanceRequestDetails(RequestId);
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


        private string GetMonth(int month)
        {
            return CultureInfo.CurrentCulture.
           DateTimeFormat.GetMonthName(month);
           
        }

        //for viewing history of a particular vehicle
        public async Task<IActionResult>  VehicleRequestMaintanceHistory(int VehicleId)

        {
            try
            {
                var res = await vehicleService.GetVehicleById(VehicleId);
                ViewBag.VehicleRegistrationNumber = res.vehicle.RegistrationNumber;
                var RequestMaintenanceHistory = requestService.GetAllVehicleMaintenanceRequest()
                                           .Item1.Where(x => x.VehicleId == VehicleId);
                List<int> Repartitions = new List<int>();

                //select request for the months in the current year
                var request = RequestMaintenanceHistory
                    .Select(x => GetMonth(x.Date.Month)).Distinct()
                    .ToList();

                if (request.Count != 0)
                {
                    foreach (var item in request)
                    {
                        Repartitions.Add(RequestMaintenanceHistory.Count(x => GetMonth(x.Date.Month) == item));
                    }
                }
                

                var rep = Repartitions;
                ViewBag.Request = request;
                ViewBag.Rep = Repartitions.ToList();

                List<VehicleMaintenanceRequestsViewModel> results = requestService.GetAllVehicleMaintenanceRequest().Item1;

                var ApprovedVehicleRequest = new RequestVehicleViewModel
                {
                    VehicleMaintenanceRequests = results.Where(x => x.VehicleId == VehicleId).ToList(),
                };
                return View(ApprovedVehicleRequest);
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

        public void VehicleRequestMaintenanceDetails(int VehicleId)
        {
        }

        public IActionResult UploadReceipts(VehicleMaintenanceRequestDetailsViewModel model)
        {
            try
            {
                if (model.ReceiptFiles.Count == 0)
                {
                    return RedirectToAction("RequestSparePartDetails", new { ListId = model.RequestId });
                }
                else
                {
                    requestService.UploadFiles(model.ReceiptFiles, model.RequestId, GetCurrentUserName().Value);
                    return RedirectToAction("RequestSparePartDetails", new { ListId = model.RequestId });
                }
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
        public IActionResult ViewReceipts(string DocumentStreamId)
        {
            var result = requestService.GetReceiptsDocument(DocumentStreamId);

            var filedetails = result.FileStream;
            return File(filedetails, "application/*");
        }
    }
    
}
