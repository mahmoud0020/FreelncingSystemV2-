using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerSystem.Controllers
{
    public class FreelanceController : Controller
    {
        // GET: Freelance
        public ActionResult Index()
        {
            return View();
        }

        // GET: Freelance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Freelance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Freelance/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Freelance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Freelance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Freelance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Freelance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
