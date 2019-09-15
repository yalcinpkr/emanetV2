using emanetV2.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emanetV2.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AdminListViewModel viewModel = new AdminListViewModel();
            return View(viewModel);
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