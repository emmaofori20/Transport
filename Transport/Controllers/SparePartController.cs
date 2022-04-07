using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.Controllers
{
    public class SparePartController : Controller
    {
        // GET: SparePartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SparePartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SparePartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SparePartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SparePartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SparePartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SparePartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SparePartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
