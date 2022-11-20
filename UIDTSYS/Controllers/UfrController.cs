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
    public class UfrController : Controller
    {
        private readonly UfrService _ufrService;

        public UfrController(UfrService ufrService)
        {
            _ufrService = ufrService;
        }

        // GET: Ufr
        public ActionResult Index()
        {
            return View(_ufrService.Get());
        }

        // GET: Ufr/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ufr = _ufrService.Get(id);

            if (ufr == null)
            {
                return NotFound();
            }

            return View(ufr);
        }

        // GET: Ufr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ufr/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ufr ufr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ufrService.Create(ufr);
                    return RedirectToAction(nameof(Index));
                }
                return View(ufr);

            }
            catch
            {
                return View();
            }
        }

        // GET: Ufr/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ufr = _ufrService.Get(id);

            if (ufr == null)
            {
                return NotFound();
            }

            return View(ufr);
        }

        // POST: Ufr/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Ufr ufrIn)
        {
            try
            {
                if (id != ufrIn.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _ufrService.Update(id, ufrIn);
                    return RedirectToAction(nameof(Index));
                }
                return View(ufrIn);
            }
            catch
            {
                return View();
            }
        }
        // GET: Ufr/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ufr = _ufrService.Get(id);

            if (ufr == null)
            {
                return NotFound();
            }
            return View(ufr);
        }
        // POST: Ufr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var ufr = _ufrService.Get(id);

                if (ufr == null)
                {
                    return NotFound();
                }
                _ufrService.Delete(ufr.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}