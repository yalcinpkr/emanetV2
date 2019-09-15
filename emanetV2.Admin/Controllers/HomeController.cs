using emanetV2.Admin.Models;
using emanetV2.Service;
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
        private readonly IPublicationService _publicationService;
        public HomeController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
            
        }
        public ActionResult Index()
        {
            PublicationListViewModel viewModel = new PublicationListViewModel()
            {
                Publications = _publicationService.GetAllAdmin()
            };
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