using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Controllers
{
    public class RequestController : Controller
    {
        public  IRequestService requestService;
        //CONSTRUCTOR
        public RequestController( IRequestService _requestService)
        {
            requestService = _requestService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeRequestMaintainance(RequestMaintenanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Making a Request Maintnace
                var result = requestService.MakeRequestMaintenance(model);
                return RedirectToAction("RequestSparePart", new { Id = result.VehicleMaintenanceRequestId });

            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult RequestSparePart(int Id)
        {
            ViewData["RequestSparePartId"] =Id;
            return View();
        }

        [HttpPost]
        public IActionResult RequestSparePart(List<VehicleMaintananceSparepartViewModel> model,int Id)
        {

            try
            {
                requestService.AddRequestSparePart(model, Id);
            }
            catch (Exception err)
            {
               var error = err.Message;
            }
            return View();
        }
    }
}
