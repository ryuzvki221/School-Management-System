using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIDTSYS.Services;
using UIDTSYS.Models;

namespace UIDTSYS.Controllers
{
    public class DepartementController : Controller
    {
        private readonly DepartementService _departementService;

        public DepartementController(DepartementService departementService)
        {
            _departementService = departementService;
        }

        // GET: Departement
        public ActionResult Index()
        {
            return View(_departementService.Get());
        }

        // GET: Departement/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departement = _departementService.Get(id);

            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }

        // GET: Departement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departement departement)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departementService.Create(departement);
                    return RedirectToAction(nameof(Index));
                }
                return View(departement);

            }
            catch
            {
                return View();
            }
        }

        // GET: Departement/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departement = _departementService.Get(id);

            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }

        // POST: Departement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Departement departementIn)
        {
            try
            {
                if (id != departementIn.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _departementService.Update(id, departementIn);
                    return RedirectToAction(nameof(Index));
                }
                return View(departementIn);
            }
            catch
            {
                return View();
            }
        }
        // GET: Departement/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departement = _departementService.Get(id);

            if (departement == null)
            {
                return NotFound();
            }
            return View(departement);
        }
        // POST: Departement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var departement = _departementService.Get(id);

                if (departement == null)
                {
                    return NotFound();
                }
                _departementService.Delete(departement.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}