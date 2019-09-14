using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emanetV2.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AdminListViewModel viewModel = new AdminListViewModel();
            return View(viewModel);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(AdminNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            return RedirectToAction("Edit", new { adminId = 1 });
        }

        public ActionResult Edit(int? adminId)
        {
            if (adminId == null)
                return RedirectToAction("Index");

            // Find Admin
            // Admin to viewModel
            AdminEditViewModel viewModel = new AdminEditViewModel();

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(AdminEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            return View();
        }

        public ActionResult Publish(int? adminId)
        {
            if (adminId == null)
                return RedirectToAction("Index");

            // Publish
            return RedirectToAction("Index");
        }

        public ActionResult Draft(int? adminId)
        {
            if (adminId == null)
                return RedirectToAction("Index");

            // Draft
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? adminId)
        {
            if (adminId == null)
                return RedirectToAction("Index");

            // Remove
            return RedirectToAction("Index");
        }

    }
}