using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models;
using Transport.Models.Data;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Controllers
{
    public class InvoiceController : Controller
    {
        public IRequestService requestService;
        private readonly IInvoiceService invoiceService;
        private readonly IRoutineService routineService;

        public InvoiceController(IRequestService _requestService, IInvoiceService invoiceService, IRoutineService routineService)
        {
            requestService = _requestService;
            this.invoiceService = invoiceService;
            this.routineService = routineService;
        }
        // GET: MaintenanceController
        public ActionResult Index()
        {
            List<VehicleMaintenanceRequestsViewModel> results = requestService.GetAllVehicleMaintenanceRequest().Item1;
            var data = new RequestVehicleViewModel
            {
                VehicleMaintenanceRequests = results,
            };
            return View(data);
        }

        public PartialViewResult AllRequestMaintenance()
        {

            try
            {
                List<VehicleMaintenanceRequestsViewModel> results = requestService.GetAllVehicleMaintenanceRequest().Item1;
                var data = new RequestVehicleViewModel
                {
                    VehicleMaintenanceRequests = results,
                };
                return PartialView("_AllVehicleRequestPartialView",data);

            }
            catch (Exception err)
            {
                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return PartialView();
            }
        } 
        
        public PartialViewResult AllRoutineMaintenance()
        {

            try
            {
                List<VehicleRoutineMaintenance> results = routineService.GetVehicleRoutineMaintenances(); 
                var data = new RequestVehicleViewModel
                {
                    VehicleRoutineMaintenanceRequest = results,
                };
                return PartialView("_AllRoutineMaintenancePartialView", data);

            }
            catch (Exception err)
            {
                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return PartialView();
            }
        }

        public PartialViewResult PendingVehicleRequest()
        {
            try
            {
                List<VehicleMaintenanceRequestsViewModel> results = requestService.GetAllVehicleMaintenanceRequest().Item1;
                var PendingVehicleRequest = new RequestVehicleViewModel
                {
                    VehicleMaintenanceRequests = results.Where(x=>x.Status == "Pending").ToList(),
                };
                return PartialView("_PendingVehicleRequestPartialView", PendingVehicleRequest);
            }
            catch (Exception err)
            {

                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };

                return PartialView();

            }
        }

        //Gets all Approved list for all Approved vehicles
        public PartialViewResult GetApproveRequestMaintenance()
        {
            try
            {
                List<VehicleMaintenanceRequestsViewModel> results = requestService.GetAllVehicleMaintenanceRequest().Item1;
                var ApprovedVehicleRequest = new RequestVehicleViewModel
                {
                    VehicleMaintenanceRequests = results.Where(x => x.Status == "Approved").ToList(),
                };
                return PartialView("_ApprovedVehicleRequestPartialView", ApprovedVehicleRequest);
            }
            catch (Exception err)
            {

                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };

                return PartialView();

            }
        }

        //Gets all Approved list for all completed vehicles
        public PartialViewResult GetCompletedRequestMaintenance()
        {
            try
            {
                List<VehicleMaintenanceRequestsViewModel> results = requestService.GetAllVehicleMaintenanceRequest().Item1;
                var CompletedVehicleRequest = new RequestVehicleViewModel
                {
                    VehicleMaintenanceRequests = results.Where(x => x.Status == "Completed").ToList(),
                };
                return PartialView("_CompletedVehicleRequestPartialView", CompletedVehicleRequest);
            }
            catch (Exception err)
            {

                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };

                return PartialView();

            }
        }

        //Sets a list to approved
        public void ApproveRequestMaintenance(int RequestId)
        {
            try
            {
                invoiceService.ApproveInvoice(RequestId);
            }
            catch (Exception err)
            {

                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };

            }
        }

        //invalid request///
        public void InvalidRequestMaintenance(int RequestId)
        {
            try
            {
                invoiceService.InvalidInvoice(RequestId);
            }
            catch (Exception err)
            {

                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };

            }
        }

        //Unapproving a request List 
        public void UnApproveMaintenance(int RequestId)
        {
            try
            {
                invoiceService.UnApprovedInvoice(RequestId);
            }
            catch (Exception err)
            {

                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };

            }

        }


        #region RequestTypes
        public IActionResult ViewRequestType()
        {
            var res = new RequestTypesViewModel();
            res.RequestTypes = invoiceService.GetRequestTypes();
            return View(res);
        }

        [HttpPost]
        public IActionResult CreateRequestType(RequestTypesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    invoiceService.CreateRequestType(model);
                    return RedirectToAction("ViewRequestType");
                }
               return RedirectToAction("ViewRequestType");


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

        public IActionResult EditRequestType(int RequestTypeId)
        {
            var res = invoiceService.GetSingleRequestType(RequestTypeId);
            var results = new RequestTypeNameAndChargeViewModel
            {
                RequestTypeId = res.RequestTypeId,
                RequestTypeName = res.RequestTypeName,
                RequestTypeChargeName = res.RequestTypeCharges.FirstOrDefault(x=>x.IsActive == true && x.RequestTypeId == RequestTypeId).ChargeName,
                RequestTypeChargeValue = res.RequestTypeCharges.FirstOrDefault(x=>x.IsActive == true && x.RequestTypeId == RequestTypeId).ChargeValue,
                RequestTypeChargeId = res.RequestTypeCharges.FirstOrDefault(x=>x.IsActive == true && x.RequestTypeId == RequestTypeId).RequestTypeChargeId,
            };
            return View(results);
        }
        [HttpPost]
        public IActionResult EditRequestType(RequestTypeNameAndChargeViewModel model )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    invoiceService.EditRequestType(model);
                    return RedirectToAction("ViewRequestType");
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

        public IActionResult DeleteRequestType(int RequestTypeId)
        {
            invoiceService.DeleteRequestType(RequestTypeId);
            return RedirectToAction("ViewRequestType");
        }
        #endregion
    }
}
