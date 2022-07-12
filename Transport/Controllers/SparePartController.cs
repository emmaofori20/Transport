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
            try
            {
                var results = new SparePartRoutineActiviesViewModel()
                {
                    RoutineMaintenanceActivities = sparePartService.GetRoutineMaintenanceActivities(),
                    SparePartQuantities = sparePartService.GetAllSpareParts().Item1
                };

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

        // GET: SparePartController/Details/5
        public IActionResult SparePartDetail(int SpartPartId)
        {
            try
            {
                var results = sparePartService.GetSparePart(SpartPartId);

                var sparePartsHistory = sparePartService.GetAllSpareParts().AllSparePartsHistory.Where(x => x.SparePartId == SpartPartId);
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
            catch (Exception err)
            {

                var error = new ErrorViewModel
                {
                    RequestId = err.Message,
                };
                return View("Error", error);
            }
          
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
                   return RedirectToAction("Index");
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
            try
            {
                var results = sparePartService.GetSparePart(SparePartId);
                SparePartViewModel sparePart = new SparePartViewModel
                {
                    SparePartId = results.SparePartId,
                    SparePartName = results.SparePart.SparePartName,
                    SparePartQuantity = (int)results.QuantityLeft
                };
                return View(sparePart);
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
        /// <summary>
        /// 
        /// 
        /// 
        /// 
        /// For Routine Actives
        /// 

        public IActionResult CreateRoutineActivity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoutineActivity(RoutineActivityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sparePartService.CreateRoutineActivity(model);

                    return RedirectToAction("Index");
                }
                return View();

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
            try
            {
                sparePartService.DeleteRoutineActivity(RoutineActivityId);
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

        public IActionResult ViewRoutineActvity(int RoutineActivityId)
        {
            try
            {
                var results = sparePartService.GetRoutineMaintenanceActivities().Where(x => x.RoutineMaintenanceActivityId == RoutineActivityId).FirstOrDefault();
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
        public IActionResult ViewRoutineActvity(int RoutineActivityId, RoutineMaintenanceActivity model )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sparePartService.EditRoutineActivity(model);
                    return RedirectToAction("Index");
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

        
    }
}
