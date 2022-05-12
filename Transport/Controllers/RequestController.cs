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
    public class RequestController : Controller
    {
        public IRequestService requestService;
        //CONSTRUCTOR
        public RequestController(IRequestService _requestService)
        {
            requestService = _requestService;
        }
        public IActionResult Index()
        {
            try
            {

                List<VehicleMaintenanceRequestsViewModel> results = requestService.GetAllVehicleMaintenanceRequest();
                var data = new RequestVehicleViewModel
                {
                    VehicleMaintenanceRequests = results,
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
                    //returns true after method is completed
                    requestService.AddRequestSparePart(model, Id);
                    //return Json(Url.Action("RequestSparePartDetails", "Request"));
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
                requestService.DeleteVehicleRequestMaintenance(RequestId);
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

                    requestService.EdiVehicleRequestMaintenance(model, RequestId);

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

        //for viewing history of a particular vehicle
        public IActionResult VehicleRequestMaintanceHistory(int VehicleId)
        {
            return View();
        }
    }
}
