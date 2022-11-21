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
    public class FiliereController : Controller
    {
        private readonly FiliereService _filiereService;

        public FiliereController(FiliereService filiereService)
        {
            _filiereService = filiereService;
        }

        // GET: Filiere
        public ActionResult Index()
        {
            return View(_filiereService.Get());
        }

        // GET: Filiere/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = _filiereService.Get(id);

            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // GET: Filiere/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filiere/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filiere filiere)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _filiereService.Create(filiere);
                    return RedirectToAction(nameof(Index));
                }
                return View(filiere);
            }
            catch
            {
                return View();
            }
        }

        // GET: Filiere/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = _filiereService.Get(id);

            if (filiere == null)
            {
                return NotFound();
            }
            return View(filiere);
        }

        // POST: Filiere/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Filiere filiere)
        {
            try
            {
                if (id != filiere.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _filiereService.Update(id, filiere);
                    return RedirectToAction(nameof(Index));
                }
                return View(filiere);
            }
            catch
            {
                return View();
            }
        }

        // GET: Filiere/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = _filiereService.Get(id);

            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // POST: Filiere/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Filiere filiere)
        {
            try
            {
                _filiereService.Delete(filiere.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Filiere/GetByDepartement/5

        public ActionResult GetByDepartement(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = _filiereService.GetByDepartement(id);

            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // POST: Filiere/GetByDepartement/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetByDepartement(string id, Filiere filiere)
        {
            try
            {
                _filiereService.GetByDepartement(filiere.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}