﻿using Microsoft.AspNetCore.Http;
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
    public class InvoiceController : Controller
    {
        public IRequestService requestService;
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IRequestService _requestService, IInvoiceService invoiceService)
        {
            requestService = _requestService;
            this.invoiceService = invoiceService;
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
                
                return PartialView();

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
    }
}
