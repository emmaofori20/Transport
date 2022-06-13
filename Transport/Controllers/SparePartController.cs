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
    public class SparePartController : Controller
    {
        private readonly ISparePartService sparePartService;

        public SparePartController(ISparePartService sparePartService)
        {
            this.sparePartService = sparePartService;
        }
        // GET: SparePartController
        public IActionResult Index()
        {
            var results = new SparePartRoutineActiviesViewModel()
            {
                RoutineMaintenanceActivities = sparePartService.GetRoutineMaintenanceActivities(),
                SparePartQuantities = sparePartService.GetAllSpareParts().Item1
            };
            
            return View(results);
        }

        // GET: SparePartController/Details/5
        public IActionResult SparePartDetail(int SpartPartId)
        {
            var results = sparePartService.GetSparePart(SpartPartId);

            var sparePartsHistory = sparePartService.GetAllSpareParts().spareparts.Where(x => x.SparePartId == SpartPartId);
            List<int> Repartitions = new List<int>();
            var sparepart = sparePartsHistory.Select(x => x.CreatedOn.Month).Distinct().ToList();
            foreach (var item in sparepart)
            {
                Repartitions.Add(sparePartsHistory.Count(x => x.CreatedOn.Month == item));
            }
            var rep = Repartitions;
            ViewBag.sparepart = sparepart;
            ViewBag.Rep = Repartitions.ToList();

            return View(results);
        }

        // GET: SparePartController/Create
        public ActionResult CreateSparePart()
        {
            return View();
        }

        // POST: SparePartController/Create
        [HttpPost]
        public IActionResult CreateSparePart(SparePartViewModel model )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sparePartService.AddSparePart(model);
                    RedirectToAction("Index");
                }
                return View(model);
            }
            catch(Exception err)
            {
                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return View("Error", error);
            }
        }

        // GET: SparePartController/Edit/5
        public ActionResult EditSparePart(int SparePartId)
        {
            var results = sparePartService.GetSparePart(SparePartId);
            SparePartViewModel sparePart = new SparePartViewModel
            {
                SparePartId = results.SparePartId,
                SparePartName = results.SparePart.SparePartName,
                SparePartQuantity = results.Quantity
            };
            return View(sparePart);
        }

        // POST: SparePartController/Edit/5
        [HttpPost]
        public IActionResult EditSparePart(int SpartPartid, SparePartViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sparePartService.EditSparePart(model);
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch(Exception err)
            {
                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return View("Error", error);
            }
        }

        // GET: SparePartController/Delete/5
        public IActionResult DeleteSparePart(int SpartPartid)
        {
            try
            {
                sparePartService.DeleteSparePart(SpartPartid);
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

        public IActionResult DeleteRoutineActivity(int RoutineActivityId)
        {
            sparePartService.DeleteRoutineActivity(RoutineActivityId);
            return RedirectToAction("Index");
        }

        public IActionResult ViewRoutineActvity(int RoutineActivityId)
        {
            var results= sparePartService.GetRoutineMaintenanceActivities().Where(x => x.RoutineMaintenanceActivityId == RoutineActivityId).FirstOrDefault();
            return View(results);
        }

        
    }
}
